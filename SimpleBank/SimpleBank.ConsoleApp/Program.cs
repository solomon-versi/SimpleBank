using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using SimpleBank.Core.Data.DataAccess;
using SimpleBank.Core.Data.Repositories.Abstractions;
using SimpleBank.Core.Data.Repositories.Implementations;
using SimpleBank.Core.Models;
using SimpleBank.Core.Services;
using SimpleBank.Core.Utils;
using Unity;

namespace SimpleBank.ConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string accountDataConnectionString =
                @"C:\Users\DavitMargvelashvili\Desktop\SimpleBank\SimpleBank\SimpleBank.Core\Accounts.csv";

            string operationsDataConnectionString =
                @"C:\Users\DavitMargvelashvili\Desktop\SimpleBank\SimpleBank\SimpleBank.Core\Operations.csv";

            Fx.Initialize(new Dictionary<string, CurrencyRate>
            {
                ["GEL:USD"] = new CurrencyRate(CurrencyCode.GEL, CurrencyCode.USD, 0.50m),
                ["USD:GEL"] = new CurrencyRate(CurrencyCode.USD, CurrencyCode.GEL, 2.00m),
            });

            Injector.Default
                .Register<Application>()
                .Register<IOperationService, OperationService>()
                .Register(f => f.Resolve<OperationRepoFactory>().GetOperationRepo())
                .Register<OperationRepoFactory>()
                .Register<IRepository<Account, int>, AccountsCsvRepository>()
                .Register<IDataReader<string>>(_ => new FileDataStore(accountDataConnectionString))
                .Register<IDataWriter<string>>(_ => new FileDataStore(accountDataConnectionString))
                .Register<IDateTimeProvider, DateTimeProvider>()
                .Resolve<Application>()
                .Run();

            //new UnityContainer()
            //       .RegisterType<Application>()
            //       .RegisterType<IOperationService, OperationService>()
            //       .RegisterFactory<IRepository<Operation, long>>(f => f.Resolve<OperationRepoFactory>().GetOperationRepo())
            //       .RegisterType<OperationRepoFactory>()
            //       .RegisterType<IRepository<Account, int>, AccountsCsvRepository>()
            //       .RegisterFactory<IDataReader<string>>(_ => new FileDataStore(accountDataConnectionString))
            //       .RegisterFactory<IDataWriter<string>>(_ => new FileDataStore(accountDataConnectionString))
            //       .RegisterType<IDateTimeProvider, DateTimeProvider>()
            //       .Resolve<Application>()
            //       .Run();
        }
    }

    internal class OperationRepoFactory
    {
        public IRepository<Operation, long> GetOperationRepo()
        {
            var fileStore = new FileDataStore(
                  @"C:\Users\DavitMargvelashvili\Desktop\SimpleBank\SimpleBank\SimpleBank.Core\Operations.csv");
            return new OperationsCsvRepository(fileStore, fileStore);
        }
    }

    public class Injector
    {
        public static readonly Injector Default = new Injector();

        private readonly Dictionary<Type, Type> _registry = new Dictionary<Type, Type>();
        private readonly Dictionary<Type, Lazy<object>> _factoryRegistry = new Dictionary<Type, Lazy<object>>();

        public Injector Register<TAbstract, TConcrete>() where TConcrete : class, TAbstract
        {
            _registry[typeof(TAbstract)] = typeof(TConcrete);
            return this;
        }

        public Injector Register<TConcrete>() where TConcrete : class
        {
            _registry[typeof(TConcrete)] = typeof(TConcrete);
            return this;
        }

        public Injector Register<TAbstract>(Func<Injector, TAbstract> ctor)
        {
            _factoryRegistry[typeof(TAbstract)] = new Lazy<object>(() => ctor(this));
            return this;
        }

        public T Resolve<T>()
        {
            return (T)ResolveInternal(typeof(T));
        }

        private object ResolveInternal(Type keyType)
        {
            if (_factoryRegistry.TryGetValue(keyType, out var result))
                return result.Value;

            if (!_registry.TryGetValue(keyType, out var resultType))
                throw new Exception("Requested Type not registered");

            var constructor = resultType.GetConstructors().Aggregate(WithMaxParameters);

            var ctorParamInfos = constructor.GetParameters();
            if (ctorParamInfos.Length == 0)
                return Activator.CreateInstance(resultType);

            var ctorParams = ctorParamInfos.Select(p => ResolveInternal(p.ParameterType)).ToArray();
            return Activator.CreateInstance(resultType, ctorParams);
        }

        private static ConstructorInfo WithMaxParameters(ConstructorInfo max, ConstructorInfo current)
            => max.GetParameters().Length >= current.GetParameters().Length ? max : current;
    }
}
using AutoMapper;
using SimpleBank.Core.Data.Repositories.Abstractions;
using SimpleBank.Core.Models;
using SimpleBank.Core.Services;
using SimpleBank.Core.Utils;
using SimpleBank.Data;
using System.Collections.Generic;
using Unity;

namespace SimpleBank.ConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Fx.Initialize(new Dictionary<string, CurrencyRate>
            {
                ["GEL:USD"] = new CurrencyRate(CurrencyCode.GEL, CurrencyCode.USD, 0.50m),
                ["USD:GEL"] = new CurrencyRate(CurrencyCode.USD, CurrencyCode.GEL, 2.00m),
            });

            var mapperProfile = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Data.Models.Account, Account>()
                    .ForMember(dest => dest.Balance,
                        opt => opt.MapFrom(src => new Money(src.Currency, src.Balance)));

                cfg.CreateMap<Account, Data.Models.Account>()
                    .ForMember(dest => dest.Balance,
                        opt => opt.MapFrom(src => src.Balance.Amount))
                    .ForMember(dest => dest.Currency,
                        opt => opt.MapFrom(src => src.Balance.Currency));
            });

            var mapper = mapperProfile.CreateMapper();

            new UnityContainer()
                   .RegisterType<Application>()
                   //.RegisterType<IOperationService, OperationService>()
                   .RegisterSingleton<SimpleBankDbContext>()
                   .RegisterInstance(mapper)
                   .RegisterType<AccountService>()
                   .RegisterType<IRepository<Account, int>, AccountsRepository>()
                   .RegisterType<IDateTimeProvider, DateTimeProvider>()
                   .Resolve<Application>()
                   .Run();
        }
    }
}
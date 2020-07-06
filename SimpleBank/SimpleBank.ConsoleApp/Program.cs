using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SimpleBank.Core.Data.Repositories.Abstractions;
using SimpleBank.Core.Models;
using SimpleBank.Core.Services;
using SimpleBank.Core.Utils;
using SimpleBank.Data;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SimpleBank.Data.Maps;

namespace SimpleBank.ConsoleApp
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Fx.Initialize(new Dictionary<string, CurrencyRate>
            {
                ["GEL:USD"] = new CurrencyRate(CurrencyCode.GEL, CurrencyCode.USD, 0.50m),
                ["USD:GEL"] = new CurrencyRate(CurrencyCode.USD, CurrencyCode.GEL, 2.00m),
            });

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) => Host
                .CreateDefaultBuilder(args)
                .ConfigureServices(services => services
                    .AddHostedService<Application>()
                    .AddDbContext<SimpleBankDbContext>(options => options
                        .UseSqlServer(@"Data Source = (localdb)\MSSQLLocalDb; Initial Catalog = SimpleBank"))
                    .AddScoped<IOperationService, OperationService>()
                    .AddScoped<AccountService>()
                    .AddScoped<IRepository<Account, int>, AccountRepository>()
                    .AddScoped<IRepository<Operation, long>, OperationRepository>()
                    .AddScoped<IRepository<Customer, int>, CustomerRepository>()
                    .AddSingleton<IDateTimeProvider, DateTimeProvider>()
                    .AddAutoMapper(typeof(MappingProfile)));
    }
}
using Microsoft.EntityFrameworkCore;
using SimpleBank.Data.Models;

#nullable disable

namespace SimpleBank.Data
{
    public class SimpleBankDbContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Operation> Operations { get; set; }
        public DbSet<CurrencyRate> CurrencyRates { get; set; }

        public SimpleBankDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}

#nullable enable
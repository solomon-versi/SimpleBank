using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Text;
using SimpleBank.Core.Models;

namespace SimpleBank.Data.Models
{
    public class Account
    {
        public int Id { get; set; }

        [Required]
        [StringLength(22)]
        public string Iban { get; set; }

        public decimal Balance { get; set; }
        public CurrencyCode Currency { get; set; }
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public Customer Customer { get; set; }
    }

    public static class AccountExt
    {
        public static Core.Models.Account ToAccountModel(this Account self) => new Core.Models.Account(self.Id)
        {
            Balance = new Money(self.Currency, self.Balance),
            CustomerId = self.CustomerId,
            Name = self.Name,
            Iban = self.Iban
        };

        public static Account ToAccountEntity(this Core.Models.Account self) => new Account
        {
            Iban = self.Iban,
            Balance = self.Balance.Amount,
            Currency = self.Balance.Currency,
            CustomerId = self.CustomerId,
            Name = self.Name
        };
    }
}
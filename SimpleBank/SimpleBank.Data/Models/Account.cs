using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    }
}
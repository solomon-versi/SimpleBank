using SimpleBank.Core.Models;
using System;

#nullable disable

namespace SimpleBank.Data.Models
{
    public class Operation
    {
        public long Id { get; set; }
        public OperationType Type { get; set; }
        public CurrencyCode Currency { get; set; }
        public decimal Amount { get; set; }
        public int AccountId { get; set; }
        public int CustomerId { get; set; }
        public DateTime HappenedAt { get; set; }
        public DateTime CreatedAt { get; set; }

        public Customer Customer { get; set; }
        public Account Account { get; set; }
    }
}

#nullable enable
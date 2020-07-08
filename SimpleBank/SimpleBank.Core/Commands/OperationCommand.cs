using System;
using SimpleBank.Core.Models;

namespace SimpleBank.Core.Commands
{
    public class OperationCommand
    {
        public int AccountId { get; set; }
        public decimal Amount { get; set; }
        public CurrencyCode Currency { get; set; }
        public DateTime HappenedAt { get; set; }
    }
}
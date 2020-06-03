using System;

namespace SimpleBank.Core.Models
{
    public class Operation
    {
        public long Id { get; set; }
        public byte Type { get; set; }
        public string Currency { get; set; }
        public decimal Amount { get; set; }
        public int AccountId { get; set; }
        public int CustomerId { get; set; }
        public DateTime HappenedAt { get; set; }
    }
}
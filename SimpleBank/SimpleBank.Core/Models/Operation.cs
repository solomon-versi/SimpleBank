using System;
using System.Reflection.Metadata.Ecma335;
using SimpleBank.Core.Models.Abstractions;
using SimpleBank.Core.Services;

namespace SimpleBank.Core.Models
{
    public sealed class Operation : IDomainObject<long>
    {
        public Operation(long id)
        {
            Id = id;
        }

        public long Id { get; }
        public OperationType Type { get; set; }
        public CurrencyCode Currency { get; set; }
        public decimal Amount { get; set; }
        public int AccountId { get; set; }
        public int CustomerId { get; set; }
        public DateTime HappenedAt { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
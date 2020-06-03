using System;
using System.Reflection.Metadata.Ecma335;

namespace SimpleBank.Core.Models
{
    public sealed class Operation : IEquatable<Operation>
    {
        public Operation(long id)
        {
            Id = id;
        }

        public long Id { get; }
        public byte Type { get; set; }
        public string Currency { get; set; }
        public decimal Amount { get; set; }
        public int AccountId { get; set; }
        public int CustomerId { get; set; }
        public DateTime HappenedAt { get; set; }

        public bool Equals(Operation other)
        {
            return Id == other?.Id;
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Operation);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (int)Id;
            }
        }
    }
}
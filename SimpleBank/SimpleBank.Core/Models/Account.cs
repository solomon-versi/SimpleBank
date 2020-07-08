using System;

namespace SimpleBank.Core.Models
{
    public sealed class Account : IEquatable<Account>
    {
        public Account(int id)
        {
            Id = id;
        }

        public int Id { get; }
        public string Iban { get; set; }
        public string Currency { get; set; }
        public decimal Balance { get; set; }
        public int CustomerId { get; set; }
        public string Name { get; set; }

        public bool Equals(Account other)
        {
            return Id == other?.Id;
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Account);
        }

        public override int GetHashCode()
        {
            return Id;
        }
    }
}
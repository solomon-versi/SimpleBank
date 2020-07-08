using System;
using System.Reflection.Metadata.Ecma335;

namespace SimpleBank.Core.Models
{
    public sealed class Customer : IEquatable<Customer>
    {
        public Customer(int id)
        {
            Id = id;
        }

        public int Id { get; }
        public string Name { get; set; }
        public string IdentityNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public byte Type { get; set; }

        public bool Equals(Customer other)
        {
            return Id == other?.Id;
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Customer);
        }

        public override int GetHashCode()
        {
            return Id;
        }
    }
}
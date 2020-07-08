using System;
using System.Net;
using SimpleBank.Core.Models.Abstractions;

namespace SimpleBank.Core.Models
{
    public sealed class Account : IDomainObject<int>
    {
        public Account(int id)
        {
            Id = id;
        }

        public int Id { get; }

        public Iban Iban { get; set; }

        public Money Balance { get; set; }
        public int CustomerId { get; set; }
        public string Name { get; set; }
    }
}
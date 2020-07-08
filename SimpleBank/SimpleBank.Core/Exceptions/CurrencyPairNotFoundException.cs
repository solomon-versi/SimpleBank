using System;
using System.Collections.Generic;
using System.Text;
using SimpleBank.Core.Models;

namespace SimpleBank.Core.Exceptions
{
    public class CurrencyPairNotFoundException : DomainException
    {
        public CurrencyPairNotFoundException(CurrencyCode @base, CurrencyCode quote) : base($"Currency pair '{@base}:{quote}' not found")
        {
        }
    }
}
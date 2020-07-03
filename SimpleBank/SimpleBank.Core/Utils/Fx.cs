using System;
using System.Collections.Generic;
using SimpleBank.Core.Models;

namespace SimpleBank.Core.Utils
{
    public static class Fx
    {
        public static Dictionary<string, CurrencyRate> Rates { get; private set; }

        public static void Initialize(Dictionary<string, CurrencyRate> currencyRate)
        {
            Rates = currencyRate;
        }

        public static Money Exchange(decimal amount, CurrencyCode from, CurrencyCode to)
        {
            if (from == to || amount == 0)
                return new Money(from, amount);

            if (amount > 0m) // EUR:USD = 1.13
            {
                if (!Rates.TryGetValue($"{from}:{to}", out var rate))
                    throw new Exception("Not Found");  // TODO კონკრეტული exception
                return new Money(to, amount * rate.Value);
            }
            else
            {
                if (!Rates.TryGetValue($"{to}:{from}", out var rate))
                    throw new Exception("Not Found");  // TODO კონკრეტული exception
                return new Money(to, amount / rate.Value);
            }
        }

        public static Money Buy(CurrencyCode fromCurrency, decimal requestedAmount, CurrencyCode requestedCurrency)
        {
            if (!Rates.TryGetValue($"{requestedCurrency}:{fromCurrency}", out var rate))
                throw new Exception("Not Found");  // TODO კონკრეტული exception
            return new Money(requestedCurrency, requestedAmount / rate.Value);
        }

        public static Money Sell(CurrencyCode fromCurrency, decimal requestedAmount, CurrencyCode requestedCurrency)
        {
            if (!Rates.TryGetValue($"{fromCurrency}:{requestedCurrency}", out var rate))
                throw new Exception("Not Found");  // TODO კონკრეტული exception
            return new Money(requestedCurrency, requestedAmount * rate.Value);
        }
    }
}
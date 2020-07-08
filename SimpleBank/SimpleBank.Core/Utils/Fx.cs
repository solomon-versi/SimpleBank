using System;
using System.Collections.Generic;
using SimpleBank.Core.Exceptions;
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
                    throw new CurrencyPairNotFoundException(from, to);
                return new Money(to, amount * rate.Value);
            }
            else
            {
                if (!Rates.TryGetValue($"{to}:{from}", out var rate))
                    throw new CurrencyPairNotFoundException(to, from);
                return new Money(to, amount / rate.Value);
            }
        }

        /// <summary>
        /// Bank is Buying Currency
        /// </summary>
        /// <param name="fromCurrency">Currency which is bought by bank</param>
        /// <param name="requestedAmount">Amount which is converted into requested currency</param>
        /// <param name="requestedCurrency">Currency which is sold by bank and returned</param>
        public static Money Buy(CurrencyCode fromCurrency, decimal requestedAmount, CurrencyCode requestedCurrency)
        {
            if (fromCurrency == requestedCurrency || requestedAmount == 0)
                return new Money(fromCurrency, requestedAmount);

            if (!Rates.TryGetValue($"{requestedCurrency}:{fromCurrency}", out var rate))
                throw new CurrencyPairNotFoundException(requestedCurrency, fromCurrency);
            return new Money(requestedCurrency, requestedAmount / rate.Value);
        }

        /// <summary>
        /// Bank is Selling Currency
        /// </summary>
        /// <param name="fromCurrency">Currency which is bought by bank</param>
        /// <param name="requestedAmount">Amount which is converted into requested currency</param>
        /// <param name="requestedCurrency">Currency which is sold by bank and returned</param>
        public static Money Sell(CurrencyCode fromCurrency, decimal requestedAmount, CurrencyCode requestedCurrency)
        {
            if (fromCurrency == requestedCurrency || requestedAmount == 0)
                return new Money(fromCurrency, requestedAmount);

            if (!Rates.TryGetValue($"{fromCurrency}:{requestedCurrency}", out var rate))
                throw new CurrencyPairNotFoundException(fromCurrency, requestedCurrency);

            return new Money(requestedCurrency, requestedAmount * rate.Value);
        }
    }
}
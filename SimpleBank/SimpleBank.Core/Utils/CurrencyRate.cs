using SimpleBank.Core.Models;

namespace SimpleBank.Core.Utils
{
    public readonly struct CurrencyRate
    {
        public readonly CurrencyCode Base;
        public readonly CurrencyCode Quote;
        public readonly decimal Value;
        public readonly bool IsCalculated;
        public readonly string Key;

        public CurrencyRate(CurrencyCode @base, CurrencyCode quote, decimal value, bool isCalculated = false)
        {
            Base = @base;
            Quote = quote;
            Value = value;
            IsCalculated = isCalculated;
            Key = $"{Base}:{Quote}";
        }
    }
}
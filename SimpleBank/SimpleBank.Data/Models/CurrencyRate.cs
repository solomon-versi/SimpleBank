using SimpleBank.Core.Models;

#nullable disable

namespace SimpleBank.Data.Models
{
    public class CurrencyRate
    {
        public int Id { get; set; }
        public CurrencyCode Base { get; set; }
        public CurrencyCode Quote { get; set; }
        public decimal Value { get; set; }
    }
}

#nullable enable
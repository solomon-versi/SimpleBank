using System;

namespace SimpleBank.Core.Utils
{
    public interface IDateTimeProvider
    {
        public DateTime Now { get; }
        public DateTime UtcNow { get; }
    }
}
using System.Collections.Generic;

namespace SimpleBank.Core.Data.FileAccess.Abstractions
{
    public interface IDataReader<out T>
    {
        IEnumerable<T> Read();
    }
}
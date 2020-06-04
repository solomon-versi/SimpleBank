using System.Collections.Generic;

namespace SimpleBank.Core.Repositories.Abstractions
{
    public interface IDataReader<out T>
    {
        IEnumerable<T> Read();
    }
}
using System.Collections.Generic;

namespace SimpleBank.Core.Data.FileAccess
{
    public interface IDataReader<out T>
    {
        IEnumerable<T> Read();
    }
}
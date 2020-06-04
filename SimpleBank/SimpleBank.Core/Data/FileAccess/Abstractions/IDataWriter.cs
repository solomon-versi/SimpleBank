using System.Collections.Generic;

namespace SimpleBank.Core.Data.FileAccess.Abstractions
{
    public interface IDataWriter<in T>
    {
        void Write(IEnumerable<T> data);
    }
}
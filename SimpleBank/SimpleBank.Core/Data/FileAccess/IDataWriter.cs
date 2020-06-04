using System.Collections.Generic;

namespace SimpleBank.Core.Data.FileAccess
{
    public interface IDataWriter<in T>
    {
        void Write(IEnumerable<T> data);
    }
}
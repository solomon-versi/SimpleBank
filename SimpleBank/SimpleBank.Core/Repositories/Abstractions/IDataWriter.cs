using System.Collections.Generic;

namespace SimpleBank.Core.Repositories.Abstractions
{
    public interface IDataWriter<in T>
    {
        void Write(IEnumerable<T> data);
    }
}
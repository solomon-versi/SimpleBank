using System;
using System.Collections.Generic;

namespace SimpleBank.Core.Repositories.Abstractions
{
    public interface IRepository<TObject, TId>
    {
        TObject GetById(TId id);

        TId Add(TObject entity);

        bool Update(TObject entity);

        bool Delete(TId id);

        IEnumerable<TObject> Query(Func<TObject, bool> where);
    }
}
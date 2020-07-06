using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using SimpleBank.Core.Models;
using SimpleBank.Core.Models.Abstractions;

namespace SimpleBank.Core.Data.Repositories.Abstractions
{
    public interface IRepository<TObject, TId> where TObject : class, IDomainObject<TId>
    {
        Task<TObject> GetById(TId id);

        Task<TObject?> GetByIdOrDefault(TId id);

        Task<TId> Add(TObject entity);

        Task<bool> Update(TObject entity);

        Task<bool> Delete(TId id);
    }
}
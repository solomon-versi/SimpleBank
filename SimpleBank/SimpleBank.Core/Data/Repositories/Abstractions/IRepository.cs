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
        Task<TObject> GetByIdAsync(TId id);

        Task<TObject?> GetByIdOrDefaultAsync(TId id);

        Task<TId> AddAsync(TObject entity);

        Task<bool> UpdateAsync(TObject entity);

        Task<bool> DeleteAsync(TId id);
    }
}
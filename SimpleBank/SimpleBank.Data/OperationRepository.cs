using System;
using System.Threading.Tasks;
using SimpleBank.Core.Data.Repositories.Abstractions;
using SimpleBank.Core.Models;

namespace SimpleBank.Data
{
    public class OperationRepository : IRepository<Operation, long>
    {
        private readonly SimpleBankDbContext _dbContext;

        public OperationRepository(SimpleBankDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Operation> GetById(long id)
        {
            throw new NotImplementedException();
        }

        public Task<Operation?> GetByIdOrDefault(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<long> Add(Operation entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Update(Operation entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Delete(long id)
        {
            throw new NotImplementedException();
        }
    }
}
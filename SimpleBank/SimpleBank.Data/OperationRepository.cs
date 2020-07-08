using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using AutoMapper;
using SimpleBank.Core.Data.Repositories.Abstractions;
using SimpleBank.Core.Models;

namespace SimpleBank.Data
{
    public class OperationRepository : IRepository<Operation, long>
    {
        private readonly SimpleBankDbContext _dbContext;
        private readonly IMapper _mapper;

        public OperationRepository(SimpleBankDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<Operation> GetByIdAsync(long id)
        {
            var operation = await _dbContext.Operations.FindAsync(id);

            if (operation is null)
                throw new Exception($"Operation with Id {id} not found"); // TODO კონკრეტული Exception

            return _mapper.Map<Operation>(operation);
        }

        public async Task<Operation?> GetByIdOrDefaultAsync(long id)
        {
            var operation = await _dbContext.Operations.FindAsync(id);

            if (operation is null)
                return null;

            return _mapper.Map<Operation>(operation);
        }

        public async Task<long> AddAsync(Operation entity)
        {
            var operation = _mapper.Map<Data.Models.Operation>(entity);
            var result = _dbContext.Operations.Add(operation);
            await _dbContext.SaveChangesAsync();
            return result.Entity.Id;
        }

        public async Task<bool> UpdateAsync(Operation entity)
        {
            var operation = _mapper.Map<Data.Models.Operation>(entity);
            _dbContext.Operations.Update(operation);
            return await _dbContext.SaveChangesAsync() != 0;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var operation = _dbContext.Operations.Find(id);
            _dbContext.Operations.Remove(operation);
            return await _dbContext.SaveChangesAsync() != 0;
        }
    }
}
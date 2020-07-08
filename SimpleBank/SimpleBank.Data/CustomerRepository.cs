using System;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using AutoMapper;
using SimpleBank.Core.Data.Repositories.Abstractions;
using SimpleBank.Core.Exceptions;
using SimpleBank.Core.Models;

namespace SimpleBank.Data
{
    public class CustomerRepository : IRepository<Customer, int>
    {
        private readonly SimpleBankDbContext _dbContext;
        private readonly IMapper _mapper;

        public CustomerRepository(SimpleBankDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<Customer> GetByIdAsync(int id)
        {
            var customer = await _dbContext.Customers.FindAsync(id);
            if (customer is null)
                throw new NotFoundException<Customer>(id);

            return _mapper.Map<Customer>(customer);
        }

        public async Task<Customer?> GetByIdOrDefaultAsync(int id)
        {
            var customer = await _dbContext.Customers.FindAsync(id);

            if (customer is null)
                return null;

            return _mapper.Map<Customer>(customer);
        }

        public async Task<int> AddAsync(Customer entity)
        {
            var customer = _mapper.Map<Data.Models.Customer>(entity);
            var result = await _dbContext.Customers.AddAsync(customer);
            await _dbContext.SaveChangesAsync();
            return result.Entity.Id;
        }

        public async Task<bool> UpdateAsync(Customer entity)
        {
            var customer = _mapper.Map<Data.Models.Customer>(entity);
            _dbContext.Customers.Update(customer);
            return await _dbContext.SaveChangesAsync() != 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var customer = _dbContext.Customers.Find(id);
            _dbContext.Customers.Remove(customer);
            return await _dbContext.SaveChangesAsync() != 0;
        }
    }
}
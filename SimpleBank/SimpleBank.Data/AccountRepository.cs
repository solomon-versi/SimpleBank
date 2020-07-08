using SimpleBank.Core.Data.Repositories.Abstractions;
using SimpleBank.Data.Models;
using System;
using System.Threading.Tasks;
using AutoMapper;
using Account = SimpleBank.Core.Models.Account;

namespace SimpleBank.Data
{
    public class AccountRepository : IRepository<Account, int>
    {
        private readonly SimpleBankDbContext _dbContext;
        private readonly IMapper _mapper;

        public AccountRepository(SimpleBankDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<Account> GetByIdAsync(int id)
        {
            var account = await _dbContext.Accounts.FindAsync(id);

            if (account is null)
                throw new Exception($"Account with Id {id} not found"); // TODO კონკრეტული Exception

            return _mapper.Map<Account>(account);
        }

        public async Task<Account?> GetByIdOrDefaultAsync(int id)
        {
            var account = await _dbContext.Accounts.FindAsync(id);
            if (account is null)
                return null;

            return _mapper.Map<Account>(account);
        }

        public async Task<int> AddAsync(Account entity)
        {
            var account = _mapper.Map<Data.Models.Account>(entity);
            var result = _dbContext.Accounts.Add(account);
            await _dbContext.SaveChangesAsync();
            return result.Entity.Id;
        }

        public async Task<bool> UpdateAsync(Account entity)
        {
            var account = _mapper.Map<Data.Models.Account>(entity);
            _dbContext.Accounts.Update(account);
            return await _dbContext.SaveChangesAsync() != 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var account = _dbContext.Accounts.Find(id);
            _dbContext.Accounts.Remove(account);
            return await _dbContext.SaveChangesAsync() != 0;
        }
    }
}
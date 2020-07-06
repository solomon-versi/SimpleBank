using SimpleBank.Core.Data.Repositories.Abstractions;
using SimpleBank.Data.Models;
using System;
using System.Threading.Tasks;
using AutoMapper;
using Account = SimpleBank.Core.Models.Account;
using Customer = SimpleBank.Core.Models.Customer;

namespace SimpleBank.Data
{
    public class AccountsRepository : IRepository<Account, int>
    {
        private readonly SimpleBankDbContext _dbContext;
        private readonly IMapper _mapper;

        public AccountsRepository(SimpleBankDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<Account> GetById(int id)
        {
            var account = await _dbContext.Accounts.FindAsync(id);

            if (account is null)
                throw new Exception($"Account with Id {id} not found"); // TODO კონკრეტული Exception

            return _mapper.Map<Account>(account);

            //return account.ToAccountModel();
        }

        public async Task<Account?> GetByIdOrDefault(int id)
        {
            var account = await _dbContext.Accounts.FindAsync(id);
            return account?.ToAccountModel();
        }

        public async Task<int> Add(Account entity)
        {
            var account = entity.ToAccountEntity();
            var result = _dbContext.Accounts.Add(account);
            await _dbContext.SaveChangesAsync();
            return result.Entity.Id;
        }

        public async Task<bool> Update(Account entity)
        {
            var account = entity.ToAccountEntity();
            _dbContext.Accounts.Update(account);
            return await _dbContext.SaveChangesAsync() != 0;
        }

        public async Task<bool> Delete(int id)
        {
            var account = _dbContext.Accounts.Find(id);
            _dbContext.Accounts.Remove(account);
            return await _dbContext.SaveChangesAsync() != 0;
        }
    }

    //public class CustomerRepository : IRepository<Customer, int>
    //{
    //    public async Task<Customer> GetById(int id)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public async Task<int> Add(Customer entity)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public async Task<bool> Update(Customer entity)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public async Task<bool> Delete(int id)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}
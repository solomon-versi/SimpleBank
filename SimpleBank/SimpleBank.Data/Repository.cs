using SimpleBank.Core.Data.Repositories.Abstractions;
using SimpleBank.Data.Models;
using System;
using Account = SimpleBank.Core.Models.Account;
using Customer = SimpleBank.Core.Models.Customer;
using Operation = SimpleBank.Core.Models.Operation;

namespace SimpleBank.Data
{
    public class AccountsRepository : IRepository<Account, int>
    {
        private readonly SimpleBankDbContext _dbContext;

        public AccountsRepository()
        {
            _dbContext = new SimpleBankDbContext();
        }

        public Account GetById(int id)
        {
            var account = _dbContext.Accounts.Find(id);
            return account?.ToAccountModel();
        }

        public int Add(Account entity)
        {
            var account = entity.ToAccountEntity();
            var result = _dbContext.Accounts.Add(account);
            _dbContext.SaveChanges();
            return result.Entity.Id;
        }

        public bool Update(Account entity)
        {
            var account = entity.ToAccountEntity();
            _dbContext.Accounts.Update(account);
            return _dbContext.SaveChanges() != 0;
        }

        public bool Delete(int id)
        {
            var account = _dbContext.Accounts.Find(id);
            _dbContext.Accounts.Remove(account);
            return _dbContext.SaveChanges() != 0;
        }
    }

    public class OperationRepository : IRepository<Operation, long>
    {
        public Operation GetById(long id)
        {
            throw new NotImplementedException();
        }

        public long Add(Operation entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(Operation entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(long id)
        {
            throw new NotImplementedException();
        }
    }

    public class CustomerRepository : IRepository<Customer, int>
    {
        public Customer GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Add(Customer entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(Customer entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
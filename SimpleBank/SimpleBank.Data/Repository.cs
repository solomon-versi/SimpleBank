using System;
using System.Collections.Generic;
using System.Text;
using SimpleBank.Core.Data.Repositories.Abstractions;
using SimpleBank.Core.Models;

namespace SimpleBank.Data
{
    public class AccountsRepository : IRepository<Account, int>
    {
        public Account GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Add(Account entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(Account entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Account> Query(Func<Account, bool> @where)
        {
            throw new NotImplementedException();
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

        public IEnumerable<Operation> Query(Func<Operation, bool> @where)
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

        public IEnumerable<Customer> Query(Func<Customer, bool> @where)
        {
            throw new NotImplementedException();
        }
    }
}
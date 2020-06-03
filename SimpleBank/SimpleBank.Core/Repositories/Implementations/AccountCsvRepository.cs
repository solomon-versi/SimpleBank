using System;
using System.Collections.Generic;
using System.Text;
using SimpleBank.Core.Models;
using SimpleBank.Core.Repositories.Abstractions;

namespace SimpleBank.Core.Repositories.Implementations
{
    public sealed class AccountCsvRepository : IAccountRepository
    {
        public Account GetAccountById(int id)
        {
            throw new NotImplementedException();
        }

        public int SaveAccount(Account customer)
        {
            throw new NotImplementedException();
        }

        public bool UpdateAccount(Account customer)
        {
            throw new NotImplementedException();
        }

        public bool DeleteAccount(Account customer)
        {
            throw new NotImplementedException();
        }
    }
}
using SimpleBank.Core.Models;

namespace SimpleBank.Core.Repositories.Abstractions
{
    public interface IAccountRepository
    {
        public Account GetAccountById(int id);

        public int SaveAccount(Account customer);

        public bool UpdateAccount(Account customer);

        public bool DeleteAccount(Account customer);
    }
}
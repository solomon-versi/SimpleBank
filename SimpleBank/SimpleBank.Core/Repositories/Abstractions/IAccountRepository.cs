using SimpleBank.Core.Models;

namespace SimpleBank.Core.Repositories.Abstractions
{
    public interface IAccountRepository
    {
        Account GetAccountById(int id);

        int SaveAccount(Account customer);

        bool UpdateAccount(Account customer);

        bool DeleteAccount(Account customer);
    }
}
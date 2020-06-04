using SimpleBank.Core.Models;

namespace SimpleBank.Core.Data.Repositories.Abstractions
{
    public interface IAccountsRepository
    {
        Account GetAccountById(int id);

        int SaveAccount(Account account);

        bool UpdateAccount(Account account);

        bool DeleteAccount(int id);
    }
}
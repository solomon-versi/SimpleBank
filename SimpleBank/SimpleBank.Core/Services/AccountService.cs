using SimpleBank.Core.Data.Repositories.Abstractions;
using SimpleBank.Core.Models;
using System.Threading.Tasks;

namespace SimpleBank.Core.Services
{
    public class AccountService
    {
        private readonly IRepository<Account, int> _accountRepository;

        public AccountService(IRepository<Account, int> accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<Account> GetAccount()
        {
            var account = await _accountRepository.GetByIdAsync(1);
            return account;
        }
    }
}
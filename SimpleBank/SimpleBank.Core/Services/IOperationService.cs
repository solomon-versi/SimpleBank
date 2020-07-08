using System.Threading.Tasks;
using SimpleBank.Core.Commands;

namespace SimpleBank.Core.Services
{
    public interface IOperationService
    {
        /// <summary>
        /// ანგარიშიდან თანხის ჩამოჭრის ოპერაცია
        /// </summary>
        Task<long> WithdrawAsync(WithdrawByAccountId command);

        /// <summary>
        /// ანგარიშზე თანხის ჩარიხვის ოპერაცია
        /// </summary>
        Task<long> Deposit(DepositByAccountId command);
    }
}
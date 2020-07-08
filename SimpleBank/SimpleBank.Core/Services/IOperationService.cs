using System.Threading.Tasks;
using SimpleBank.Core.Commands;

namespace SimpleBank.Core.Services
{
    public interface IOperationService
    {
        /// <summary>
        /// ანგარიშიდან თანხის ჩამოჭრის ოპერაცია
        /// </summary>
        Task<long> Debit(DebitByAccountId command);

        /// <summary>
        /// ანგარიშზე თანხის ჩარიხვის ოპერაცია
        /// </summary>
        Task<long> Credit(CreditByAccountId command);
    }
}
using SimpleBank.Core.Commands;

namespace SimpleBank.Core.Services
{
    public interface IOperationService
    {
        /// <summary>
        /// ანგარიშიდან თანხის ჩამოჭრის ოპერაცია
        /// </summary>
        long Debit(DebitByAccountId command);

        /// <summary>
        /// ანგარიშზე თანხის ჩარიხვის ოპერაცია
        /// </summary>
        void Credit(CreditByAccountId command);
    }
}
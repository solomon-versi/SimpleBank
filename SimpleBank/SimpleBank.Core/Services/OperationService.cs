using SimpleBank.Core.Commands;
using SimpleBank.Core.Data.Repositories.Abstractions;
using SimpleBank.Core.Exceptions;
using SimpleBank.Core.Models;
using System;
using System.Threading.Tasks;
using SimpleBank.Core.Utils;

namespace SimpleBank.Core.Services
{
    public class OperationService : IOperationService
    {
        private readonly IRepository<Account, int> _accountRepo;
        private readonly IRepository<Operation, long> _operationRepo;
        private readonly IDateTimeProvider _dateTime;

        public OperationService(
            IRepository<Account, int> accountRepo,
            IRepository<Operation, long> operationRepo,
            IDateTimeProvider dateTime)
        {
            _accountRepo = accountRepo;
            _operationRepo = operationRepo;
            _dateTime = dateTime;
        }

        /// <summary>
        /// ანგარიშიდან თანხის ჩამოჭრის ოპერაცია
        /// </summary>
        public async Task<long> WithdrawAsync(WithdrawByAccountId command)
        {
            var account = await _accountRepo.GetByIdAsync(command.AccountId);

            var operationAmount = new Money(command.Currency, command.Amount);
            if (account.Balance < operationAmount)
                throw new InsufficientFundsException(account.Id);

            account.Balance -= operationAmount;
            await _accountRepo.UpdateAsync(account);

            return await _operationRepo.AddAsync(new Operation(0)
            {
                AccountId = account.Id,
                Amount = operationAmount.Amount,
                Currency = operationAmount.Currency,
                CustomerId = account.CustomerId,
                Type = OperationType.Withdraw,
                HappenedAt = command.HappenedAt,
                CreatedAt = _dateTime.Now
            });
        }

        /// <summary>
        /// ანგარიშზე თანხის ჩარიხვის ოპერაცია
        /// </summary>
        public async Task<long> Deposit(DepositByAccountId command)
        {
            var account = await _accountRepo.GetByIdAsync(command.AccountId);

            var deposit = new Money(command.Currency, command.Amount);
            account.Balance += deposit;

            await _accountRepo.UpdateAsync(account);
            return await _operationRepo.AddAsync(new Operation(0)
            {
                AccountId = account.Id,
                CustomerId = account.CustomerId,
                Amount = deposit.Amount,
                Currency = deposit.Currency,
                Type = OperationType.Deposit,
                HappenedAt = command.HappenedAt,
                CreatedAt = _dateTime.Now
            });
        }
    }
}
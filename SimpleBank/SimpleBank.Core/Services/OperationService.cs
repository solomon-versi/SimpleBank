using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleBank.Core.Data.Repositories.Abstractions;
using SimpleBank.Core.Exceptions;
using SimpleBank.Core.Models;

namespace SimpleBank.Core.Services
{
    public class OperationCommand
    {
        public int AccountId { get; set; }
        public decimal Amount { get; set; }
        public CurrencyCode Currency { get; set; }
        public DateTime HappenedAt { get; set; }
    }

    public class DebitByAccountId : OperationCommand
    {
    }

    public class CreditByAccountId : OperationCommand
    {
    }

    public class OperationService
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
        public long Debit(DebitByAccountId command)
        {
            var account = _accountRepo.GetById(command.AccountId);

            if (account == null)
                throw new AccountNotFoundException(command.AccountId);

            var operationAmount = new Money(command.Currency, command.Amount);
            if (account.Balance < operationAmount)
                throw new InsufficientFundsException(account.Id);

            account.Balance -= operationAmount;
            _accountRepo.Update(account);

            return _operationRepo.Add(new Operation(-1)
            {
                AccountId = account.Id,
                Amount = operationAmount.Amount,
                Currency = operationAmount.Currency,
                CustomerId = account.CustomerId,
                Type = OperationType.Debit,
                HappenedAt = command.HappenedAt,
                CreatedAt = _dateTime.Now
            });
        }

        /// <summary>
        /// ანგარიშზე თანხის ჩარიხვის ოპერაცია
        /// </summary>
        public void Credit(CreditByAccountId command)
        {
            throw new NotImplementedException("თქვენ თვითონ დაწერეთ!!! :)");
        }
    }

    public interface IDateTimeProvider
    {
        public DateTime Now { get; }
        public DateTime UtcNow { get; }
    }

    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime Now => DateTime.Now;
        public DateTime UtcNow => DateTime.UtcNow;
    }

    public enum OperationType : byte
    {
        Debit = 1,
        Credit = 2,
    }
}
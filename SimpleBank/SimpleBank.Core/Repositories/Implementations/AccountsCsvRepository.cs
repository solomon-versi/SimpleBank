using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using SimpleBank.Core.Models;
using SimpleBank.Core.Repositories.Abstractions;

namespace SimpleBank.Core.Repositories.Implementations
{
    public sealed class AccountsCsvRepository : IAccountsRepository
    {
        private readonly Dictionary<int, Account> _accounts;

        private const string FilePath = @"..\..\..\Accounts.csv";

        public AccountsCsvRepository()
        {
            _accounts = File
                .ReadAllLines(FilePath)
                .Skip(1)
                .Select(s => s.ToAccount())
                .ToDictionary(a => a.Id);
        }

        public Account GetAccountById(int id)
        {
            _accounts.TryGetValue(id, out var account);
            return account;
        }

        public int SaveAccount(Account account)
        {
            // ჩვენ უნდა დაგვეგენერირებინა ახალი ექაუნთის Id.
            // რადგან _accounts Dictionary-ს Keys არის ექაუნთების Id-ები
            // ამიტომ მოვძებნე ყველაზე დიდი Id და დავუმატე ერთი
            var newId = _accounts.Keys.Max() + 1;
            _accounts[newId] = account;

            SaveChanges();
            return newId;
        }

        public bool UpdateAccount(Account account)
        {
            var accountId = account.Id;
            if (!_accounts.TryGetValue(accountId, out _))
                return false;

            _accounts[accountId] = account;

            SaveChanges();
            return true;
        }

        public bool DeleteAccount(int id)
        {
            if (!_accounts.Remove(id))
                return false;

            SaveChanges();
            return true;
        }

        private void SaveChanges()
        {
            var accountStrings = _accounts.Select(pair => $"{pair.Key},{pair.Value.ToCsv()}");
            File.WriteAllLines(FilePath, accountStrings);
        }
    }

    internal static class AccountExt
    {
        /// <summary>
        /// Iban,Currency,Balance,CustomerId,Name
        /// </summary>
        /// <returns></returns>
        internal static string ToCsv(this Account self) =>
            $"{self.Iban},{self.Currency},{self.Balance},{self.CustomerId},{self.Name ?? string.Empty}";

        /// <summary>
        /// Creates account from string
        /// </summary>
        /// <param name="self">Id,Iban,Currency,Balance,CustomerId,Name</param>
        /// <returns></returns>
        internal static Account ToAccount(this string self)
        {
            var data = self.Split(",");
            var idx = 0;

            var account = new Account(int.Parse(data[idx++]))
            {
                Iban = data[idx++],
                Currency = data[idx++],
                Balance = decimal.Parse(data[idx++]),
                CustomerId = int.Parse(data[idx++]),
                Name = data[idx],
            };

            if (string.IsNullOrWhiteSpace(account.Name))
                account.Name = null;

            return account;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Text;
using SimpleBank.Core.Models;
using SimpleBank.Core.Repositories.Abstractions;

namespace SimpleBank.Core.Repositories.Implementations
{
    public sealed class AccountsCsvRepository : GenericCsvRepository<Account, int>
    {
        public AccountsCsvRepository(IDataReader<string> dataReader, IDataWriter<string> dataWriter)
            : base(dataReader, dataWriter)
        {
        }

        protected override Account ToObject(string s)
        {
            var data = s.Split(",");
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

        protected override string ToCsv(Account obj)
        {
            return $"{obj.Iban},{obj.Currency},{obj.Balance},{obj.CustomerId},{obj.Name ?? string.Empty}";
        }

        protected override int GenerateNextId(int lastId) => lastId + 1;
    }
}
using System;
using SimpleBank.Core.Data.FileAccess;
using SimpleBank.Core.Data.Repositories.Abstractions;
using SimpleBank.Core.Models;

namespace SimpleBank.Core.Data.Repositories.Implementations
{
    public class OperationsCsvRepository : GenericCsvRepository<Operation, long>
    {
        public OperationsCsvRepository(IDataReader<string> dataReader, IDataWriter<string> dataWriter) : base(dataReader, dataWriter)
        {
        }

        protected override Operation ToObject(string s)
        {
            var data = s.Split(',');
            var idx = 0;
            return new Operation(long.Parse(data[idx++]))
            {
                Type = byte.Parse(data[idx++]),
                Currency = data[idx++],
                Amount = decimal.Parse(data[idx++]),
                AccountId = int.Parse(data[idx++]),
                CustomerId = int.Parse(data[idx++]),
                HappenedAt = DateTime.Parse(data[idx])
            };
        }

        protected override string ToCsv(Operation obj) =>
            $"{obj.Type},{obj.Currency},{obj.Amount},{obj.AccountId},{obj.CustomerId},{obj.HappenedAt}";

        protected override long GenerateNextId(long lastId) => lastId + 1;
    }
}
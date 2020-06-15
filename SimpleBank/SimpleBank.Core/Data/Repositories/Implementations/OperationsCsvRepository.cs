using System;
using System.Reflection.Metadata.Ecma335;
using SimpleBank.Core.Data.DataAccess;
using SimpleBank.Core.Data.Repositories.Abstractions;
using SimpleBank.Core.Models;
using SimpleBank.Core.Services;

namespace SimpleBank.Core.Data.Repositories.Implementations
{
    public class OperationsCsvRepository : GenericCsvRepository<Operation, long>
    {
        public OperationsCsvRepository(IDataReader<string> dataReader, IDataWriter<string> dataWriter) : base(dataReader, dataWriter)
        {
        }

        protected override long GenerateNewId(long lastId) => lastId + 1;

        protected override Operation ToObject(string s)
        {
            // Id,Type,Currency,Amount,AccountId,CustomerId,HappenedAt,CreatedAt
            var data = s.Split(',');
            var idx = 0;
            return new Operation(long.Parse(data[idx++]))
            {
                Type = Enum.Parse<OperationType>(data[idx++]),
                Currency = Enum.Parse<CurrencyCode>(data[idx++]),
                Amount = decimal.Parse(data[idx++]),
                AccountId = int.Parse(data[idx++]),
                CustomerId = int.Parse(data[idx++]),
                HappenedAt = DateTime.Parse(data[idx++]),
                CreatedAt = DateTime.Parse(data[idx])
            };
        }

        protected override string ToCsv(Operation op)
        {
            return $"{op.Type},{op.Currency},{op.Amount},{op.AccountId},{op.CustomerId},{op.HappenedAt},{op.CreatedAt}";
        }
    }
}
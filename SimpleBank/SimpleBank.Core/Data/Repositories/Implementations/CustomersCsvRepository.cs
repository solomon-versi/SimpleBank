using SimpleBank.Core.Data.FileAccess;
using SimpleBank.Core.Data.Repositories.Abstractions;
using SimpleBank.Core.Models;

namespace SimpleBank.Core.Data.Repositories.Implementations
{
    public class CustomersCsvRepository : GenericCsvRepository<Customer, int>
    {
        public CustomersCsvRepository(IDataReader<string> dataReader, IDataWriter<string> dataWriter) : base(dataReader, dataWriter)
        {
        }

        protected override Customer ToObject(string s)
        {
            var data = s.Split(',');
            var idx = 0;
            return new Customer(int.Parse(data[idx++]))
            {
                Name = data[idx++],
                IdentityNumber = data[idx++],
                PhoneNumber = data[idx++],
                Email = data[idx++],
                Type = byte.Parse(data[idx])
            };
        }

        protected override string ToCsv(Customer obj)
        {
            return $"{obj.Name},{obj.IdentityNumber},{obj.PhoneNumber},{obj.Email},{obj.Type}";
        }

        protected override int GenerateNextId(int lastId) => lastId + 1;
    }
}
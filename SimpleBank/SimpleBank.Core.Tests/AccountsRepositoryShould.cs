using System;
using System.Collections.Generic;
using System.Text;
using SimpleBank.Core.Data.FileAccess;
using SimpleBank.Core.Data.Repositories.Implementations;
using SimpleBank.Core.Models;
using Xunit;

namespace SimpleBank.Core.Tests
{
    public class MockDataStore : IDataReader<string>, IDataWriter<string>
    {
        public List<string> Data { get; }

        public MockDataStore(List<string> data)
        {
            Data = data;
        }

        public IEnumerable<string> Read()
        {
            return Data;
        }

        public void Write(IEnumerable<string> data)
        {
            Data.Clear();
            Data.AddRange(data);
        }
    }

    public class AccountsRepositoryShould
    {
        private readonly AccountsCsvRepository _repo;

        public AccountsRepositoryShould()
        {
            var dataStore = new MockDataStore(new List<string>
            {
                "Id,Iban,Currency,Balance,CustomerId,Name",
                "1,GE62TB9291655661344791,USD,6712,5,",
                "2,GE40TB2971676721474477,GEL,2485,6,My Account",
                "3,GE75TB3846363723366822,EUR,7354,7,",
                "4,GE85TB9214549758617342,RUB,940000,1,"
            });

            _repo = new AccountsCsvRepository(dataStore, dataStore);
        }

        [Fact]
        public void ReturnAccountByIdIfExists()
        {
            var expected = new Account(1)
            {
                Iban = "GE62TB9291655661344791",
                Currency = "USD",
                Balance = 6712m,
                CustomerId = 5,
                Name = null
            };

            var actual = _repo.GetById(1);

            Assert.Equal(expected.Id, actual.Id);
            Assert.Equal(expected.Iban, actual.Iban);
            Assert.Equal(expected.Currency, actual.Currency);
            Assert.Equal(expected.Balance, actual.Balance);
            Assert.Equal(expected.CustomerId, actual.CustomerId);
            Assert.Equal(expected.Name, actual.Name);
        }

        [Fact]
        public void ReturnAccountByIdIfExists_CheckName()
        {
            var expected = new Account(2)
            {
                Iban = "GE40TB2971676721474477",
                Currency = "GEL",
                Balance = 2485m,
                CustomerId = 6,
                Name = "My Account"
            };

            var actual = _repo.GetById(2);

            Assert.Equal(expected.Id, actual.Id);
            Assert.Equal(expected.Iban, actual.Iban);
            Assert.Equal(expected.Currency, actual.Currency);
            Assert.Equal(expected.Balance, actual.Balance);
            Assert.Equal(expected.CustomerId, actual.CustomerId);
            Assert.Equal(expected.Name, actual.Name);
        }
    }
}
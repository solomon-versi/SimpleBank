using SimpleBank.Core.Models;

namespace SimpleBank.Core.Repositories.Abstractions
{
    public interface ICustomerRepository
    {
        public Customer GetCustomerById(int id);

        public int SaveCustomer(Customer customer);

        public bool UpdateCustomer(Customer customer);

        public bool DeleteCustomer(Customer customer);
    }
}
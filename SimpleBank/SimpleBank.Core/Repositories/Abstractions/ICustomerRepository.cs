using SimpleBank.Core.Models;

namespace SimpleBank.Core.Repositories.Abstractions
{
    public interface ICustomerRepository
    {
        Customer GetCustomerById(int id);

        int SaveCustomer(Customer customer);

        bool UpdateCustomer(Customer customer);

        bool DeleteCustomer(Customer customer);
    }
}
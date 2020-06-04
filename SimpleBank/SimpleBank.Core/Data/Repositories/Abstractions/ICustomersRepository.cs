using SimpleBank.Core.Models;

namespace SimpleBank.Core.Data.Repositories.Abstractions
{
    public interface ICustomersRepository
    {
        Customer GetCustomerById(int id);

        int SaveCustomer(Customer customer);

        bool UpdateCustomer(Customer customer);

        bool DeleteCustomer(int id);
    }
}
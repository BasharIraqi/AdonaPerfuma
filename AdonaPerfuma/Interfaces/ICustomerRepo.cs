using AdonaPerfuma.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdonaPerfuma.Interfaces
{
    public interface ICustomerRepo
    {
        Task<List<Customer>> GetCustomers();

        Task<Customer> GetCustomer(int id);

        Task AddCustomer(Customer customer);

        Task UpdateCustomer(int id, Customer modifiedCustomer);

        Task DeleteCustomer(int id);

        Task<Customer> GetCustomerByUserId(int id);
    }
}

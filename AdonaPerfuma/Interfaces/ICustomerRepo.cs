using AdonaPerfuma.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdonaPerfuma.Interfaces
{
    public interface ICustomerRepo
    {
        Task<List<Customer>> GetCustomers();

        Task<Customer> GetCustomerById(int id);

        Task<int> AddCustomer(Customer customer);

        Task UpdateCustomer(int id, Customer modifiedCustomer);

        Task DeleteCustomer(int id);
    }
}

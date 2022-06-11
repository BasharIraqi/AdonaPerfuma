using AdonaPerfuma.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdonaPerfuma.Interfaces
{
    public interface ICustomerRepo
    {
        public Task<List<Customer>> GetCustomers();

        public Task<Customer> GetCustomerById(int id);

        public Task<int> AddCustomer(Customer customer);

        public Task UpdateCustomer(int id, Customer modifiedCustomer);

        public Task DeleteCustomer(int id);
    }
}

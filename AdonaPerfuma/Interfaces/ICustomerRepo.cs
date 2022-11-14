using AdonaPerfuma.Models;
using System.Threading.Tasks;

namespace AdonaPerfuma.Interfaces
{
    public interface ICustomerRepo
    {
        Task<object> GetCustomers();

        Task<Customer> GetCustomer(int id);

        Task<int> AddCustomer(Customer customer);

        Task UpdateCustomer(int id, Customer modifiedCustomer);

        Task DeleteCustomer(int id);

        Task<object> GetCustomerByUserId(int id);
    }
}

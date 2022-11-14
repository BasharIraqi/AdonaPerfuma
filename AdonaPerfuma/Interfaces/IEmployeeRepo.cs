using AdonaPerfuma.Models;
using System.Threading.Tasks;

namespace AdonaPerfuma.Interfaces
{
    public interface IEmployeeRepo
    {
        Task<object> GetAllEmployees();

        Task<object> GetEmployeeById(int id);

        Task AddEmployee(Employee employee);

        Task UpdateEmployee(int id, Employee modifiedEmployee);

        Task DeleteEmployee(int id);

        Task<object> GetEmployeeByUserId(int userId);
    }
}

using AdonaPerfuma.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdonaPerfuma.Interfaces
{
    public interface IEmployeeRepo
    {
        Task<List<Employee>> GetAllEmployees();

        Task<Employee> GetEmployeeById(int id);

        Task<int> AddEmployee(Employee employee);

        Task UpdateEmployee(int id, Employee modifiedEmployee);

        Task DeleteEmployee(int id);

        Task<object> GetEmployeeByUserId(int userId);
    }
}

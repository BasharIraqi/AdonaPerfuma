using AdonaPerfuma.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdonaPerfuma.Interfaces
{
    public interface IEmployeeRepo
    {
        Task<object> GetAllEmployees();

        Task<Employee> GetEmployeeById(int id);

        Task AddEmployee(Employee employee);

        Task UpdateEmployee(int id, Employee modifiedEmployee);

        Task DeleteEmployee(int id);

        Task<object> GetEmployeeByUserId(int userId);
    }
}

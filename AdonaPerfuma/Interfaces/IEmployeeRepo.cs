using AdonaPerfuma.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdonaPerfuma.Interfaces
{
    public interface IEmployeeRepo
    {
        public Task<List<Employee>> GetAllEmployees();

        public Task<Employee> GetEmployeeById(int id);

        public Task<int> AddEmployee(Employee employee);

        public Task UpdateEmployee(int id, Employee modifiedEmployee);

        public Task DeleteEmployee(int id);
    }
}

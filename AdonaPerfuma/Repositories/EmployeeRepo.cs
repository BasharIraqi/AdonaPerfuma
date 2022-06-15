using AdonaPerfuma.DB;
using AdonaPerfuma.Interfaces;
using AdonaPerfuma.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdonaPerfuma.Repositories
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private readonly PerfumaContext _context;

        public EmployeeRepo(PerfumaContext context)
        {
            _context = context;
        }

        public async Task<int> AddEmployee(Employee employee)
        {
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
            return employee.Id;
        }

        public async Task DeleteEmployee(int id)
        {
            var employee =await _context.Employees.FindAsync(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Employee>> GetAllEmployees()
        {
            var employees =await _context.Employees.ToListAsync();
            return employees;
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            var employee =await _context.Employees.FindAsync(id);
            if (employee != null)
            {
                return employee;
            }
            else
                return null;
        }

        public async Task UpdateEmployee(int id, Employee modifiedEmployee)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee != null)
            {
                employee.FirstName = modifiedEmployee.FirstName;
                employee.LastName = modifiedEmployee.LastName;
                employee.Email = modifiedEmployee.Email;
                employee.PhoneNumber = modifiedEmployee.PhoneNumber;
                employee.Address = modifiedEmployee.Address;
                employee.Age = modifiedEmployee.Age;
                employee.SalaryPerHour = modifiedEmployee.SalaryPerHour;
                employee.JobType = modifiedEmployee.JobType;
                employee.Seniority = modifiedEmployee.Seniority;
                employee.BankAccount = modifiedEmployee.BankAccount;
                employee.IsActivated = modifiedEmployee.IsActivated;
                employee.EndDate = modifiedEmployee.EndDate;
                employee.StartedDate = modifiedEmployee.StartedDate;
                employee.User = employee.User;

                _context.Employees.Update(employee);
                await _context.SaveChangesAsync();
            }
        }
    }
}

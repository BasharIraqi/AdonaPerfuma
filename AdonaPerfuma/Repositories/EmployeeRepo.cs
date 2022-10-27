using AdonaPerfuma.DB;
using AdonaPerfuma.Interfaces;
using AdonaPerfuma.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<object> GetEmployeeByUserId(int id)
        {


            var getEmployee = await (from employee in _context.Employees
                                     join User in _context.Users on employee.User.Id equals User.Id
                                     join Address in _context.Addresses on employee.Address.Id equals Address.Id
                                     join BankAccount in _context.BankAccounts on employee.BankAccount.Id equals BankAccount.Id
                                     where employee.User.Id == id
                                     select new
                                     {
                                         Id = employee.Id,
                                         FirstName = employee.FirstName,
                                         LastName = employee.LastName,
                                         Email = employee.Email,
                                         BankAccount = BankAccount,
                                         Address = Address,
                                         User = User,
                                         PhoneNumber = employee.PhoneNumber,
                                         BirthDay= employee.BirthDay,
                                         BirthMonth =employee.BirthMonth,
                                         BirthYear=employee.BirthYear,
                                         StartedDay=employee.StartedDay,
                                         StartedMonth=employee.StartedMonth,
                                         StartedYear=employee.StartedYear,
                                         JobType=employee.JobType,
                                         Seniority=employee.Seniority,
                                         Age=employee.Age,
                                         SalaryPerHour=employee.SalaryPerHour

                                     }).FirstOrDefaultAsync();

            if (getEmployee != null)
            {

                return getEmployee;
            }

            else if (getEmployee == null)
            {
                var employee = await _context.Employees.Where(emp => emp.User.Id == id).FirstOrDefaultAsync();
                if (employee != null)
                {
                    return employee;
                }
                else
                    return null;
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
                employee.BirthDay = modifiedEmployee.BirthDay;
                employee.BirthMonth=modifiedEmployee.BirthMonth;
                employee.BirthYear = modifiedEmployee.BirthYear;
                employee.StartedDay=modifiedEmployee.StartedDay;
                employee.StartedMonth=modifiedEmployee.StartedMonth;
                employee.StartedYear=modifiedEmployee.StartedYear;
                employee.User = employee.User;

                _context.Employees.Update(employee);
                await _context.SaveChangesAsync();
            }
        }
    }
}

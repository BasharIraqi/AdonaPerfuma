﻿using AdonaPerfuma.DB;
using AdonaPerfuma.Interfaces;
using AdonaPerfuma.Models;
using Microsoft.EntityFrameworkCore;
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

        public async Task AddEmployee(Employee employee)
        {
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<object> GetAllEmployees()
        {
            var employees = await (from Employees in _context.Employees

                                   select new
                                   {
                                       Id=Employees.Id,
                                       FirstName=Employees.FirstName,
                                       LastName=Employees.LastName,
                                       BirthDay=Employees.BirthDay,
                                       BirthMonth=Employees.BirthMonth,
                                       BirthYear=Employees.BirthYear,
                                       StartedDay=Employees.StartedDay,
                                       StartedMonth=Employees.StartedMonth,
                                       StartedYear=Employees.StartedYear,
                                       SalaryPerHour=Employees.SalaryPerHour,
                                       Address=Employees.Address,
                                       Age=Employees.Age,
                                       BankAccount=Employees.BankAccount,
                                       Email=Employees.Email,
                                       JobType=Employees.JobType,
                                       Seniority=Employees.Seniority,
                                       IsActivated=Employees.IsActivated,
                                       PhoneNumber=Employees.PhoneNumber,
                                       User=Employees.User,
                                   }).ToListAsync();

          if(employees!=null)
            {
                return employees; 
            }
          return null;
        }

        public async Task<object> GetEmployeeById(int id)
        {
            var employee = await (from Employee in _context.Employees
                                  where Employee.Id == id
                                  select new
                                  {
                                      Id = Employee.Id,
                                      FirstName = Employee.FirstName,
                                      LastName = Employee.LastName,
                                      BirthDay = Employee.BirthDay,
                                      BirthMonth = Employee.BirthMonth,
                                      BirthYear = Employee.BirthYear,
                                      StartedDay = Employee.StartedDay,
                                      StartedMonth = Employee.StartedMonth,
                                      StartedYear = Employee.StartedYear,
                                      SalaryPerHour = Employee.SalaryPerHour,
                                      Address = Employee.Address,
                                      Age = Employee.Age,
                                      BankAccount = Employee.BankAccount,
                                      Email = Employee.Email,
                                      JobType = Employee.JobType,
                                      Seniority = Employee.Seniority,
                                      IsActivated = Employee.IsActivated,
                                      PhoneNumber = Employee.PhoneNumber,
                                      User = Employee.User,
                                  }).FirstOrDefaultAsync();

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
                                    
                                     select new
                                     {
                                         Id = employee.Id,
                                         FirstName = employee.FirstName,
                                         LastName = employee.LastName,
                                         Email = employee.Email,
                                         BankAccount = employee.BankAccount,
                                         Address = employee.Address,
                                         User = employee.User,
                                         PhoneNumber = employee.PhoneNumber,
                                         BirthDay = employee.BirthDay,
                                         BirthMonth = employee.BirthMonth,
                                         BirthYear = employee.BirthYear,
                                         StartedDay = employee.StartedDay,
                                         StartedMonth = employee.StartedMonth,
                                         StartedYear = employee.StartedYear,
                                         JobType = employee.JobType,
                                         Seniority = employee.Seniority,
                                         Age = employee.Age,
                                         SalaryPerHour = employee.SalaryPerHour

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
                employee.BirthMonth = modifiedEmployee.BirthMonth;
                employee.BirthYear = modifiedEmployee.BirthYear;
                employee.StartedDay = modifiedEmployee.StartedDay;
                employee.StartedMonth = modifiedEmployee.StartedMonth;
                employee.StartedYear = modifiedEmployee.StartedYear;
                employee.User = modifiedEmployee.User;

                _context.Employees.Update(employee);
                await _context.SaveChangesAsync();
            }
        }
    }
}

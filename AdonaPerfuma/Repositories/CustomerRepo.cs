using AdonaPerfuma.DB;
using AdonaPerfuma.Interfaces;
using AdonaPerfuma.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdonaPerfuma.Repositories
{
    public class CustomerRepo : ICustomerRepo
    {
        private readonly PerfumaContext _context;
    
    
        public CustomerRepo(PerfumaContext context)
        {
            _context = context;
        }

        public async Task<int> AddCustomer(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
            return customer.Id;
        }

        public async Task DeleteCustomer(int id)
        {
            var customer =await _context.Customers.FindAsync(id);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Customer> GetCustomerById(int id)
        {
            var customer =await _context.Customers.FindAsync(id);
            if (customer != null)
            {
                return customer;
            }
            else
                return null;
        }

        public async Task<List<Customer>> GetCustomers()
        {
            var customers =await _context.Customers.ToListAsync();
            if (customers != null)
            {
                return customers;
            }
            else
                return null;
        }

        public async Task UpdateCustomer(int id, Customer modifiedCustomer)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer != null)
            {
                customer.FirstName = modifiedCustomer.FirstName;
                customer.LastName = modifiedCustomer.LastName;
                customer.Email = modifiedCustomer.Email;
                customer.PhoneNumber = modifiedCustomer.PhoneNumber;
                customer.Address = modifiedCustomer.Address;
                customer.Orders = modifiedCustomer.Orders;
                customer.Payment = modifiedCustomer.Payment;
                customer.User = modifiedCustomer.User;

                _context.Customers.Update(customer);
                await _context.SaveChangesAsync();
            }
        }
    }
}

using AdonaPerfuma.DB;
using AdonaPerfuma.Interfaces;
using AdonaPerfuma.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
            var isCustomerExist = await _context.Users.FirstOrDefaultAsync(user => user.Email == customer.User.Email);

            if (isCustomerExist == null)
            {
                await _context.Customers.AddAsync(customer);
                await _context.SaveChangesAsync();
                return customer.Id;
            }
            else
                return 0;
        }

        public async Task DeleteCustomer(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Customer> GetCustomer(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer != null)
            {
                return customer;
            }
            else
                return null;
        }

        public async Task<object> GetCustomerByUserId(int id)
        {


            var getCustomer = await (from customer in _context.Customers
                                     where customer.User.Id == id
                                     select new
                                     {
                                         Id = customer.Id,
                                         FirstName = customer.FirstName,
                                         LastName = customer.LastName,
                                         Email = customer.Email,
                                         Orders = customer.Orders,
                                         CreditCard = customer.CreditCard,
                                         Address = customer.Address,
                                         User = customer.User,
                                         PhoneNumber = customer.PhoneNumber
                                     }).FirstOrDefaultAsync();

            if (getCustomer != null)
            {

                return getCustomer;
            }

            else if (getCustomer == null)
            {
                var customer = await _context.Customers.Where(cus => cus.User.Id == id).FirstOrDefaultAsync();
                if (customer != null)
                {
                    return customer;
                }
                else
                    return null;
            }

            else
                return null;




        }

        public async Task<object> GetCustomers()
        {

            var customers = await (from Customers in _context.Customers
                                    
                                      select new
                                      {
                                          Id=Customers.Id,
                                          FirstName=Customers.FirstName,
                                          LastName=Customers.LastName,
                                          Email=Customers.Email,
                                          PhoneNumber=Customers.PhoneNumber,
                                          Orders=Customers.Orders,
                                          Address= Customers.Address,
                                          CreditCard=Customers.CreditCard,
                                          User=Customers.User

                                      }).ToListAsync();

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
                customer.CreditCard = modifiedCustomer.CreditCard;
                customer.User = modifiedCustomer.User;

                _context.Customers.Update(customer);
                await _context.SaveChangesAsync();
            }

        }
    }
}

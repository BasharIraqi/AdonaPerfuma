using AdonaPerfuma.DB;
using AdonaPerfuma.Interfaces;
using AdonaPerfuma.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdonaPerfuma.Repositories
{
    public class OrderRepo :IOrderRepo
    {
        private readonly PerfumaContext _context;

        public OrderRepo(PerfumaContext context)
        {
            _context = context;
        }

        public async Task<List<Order>> GetAllOrders()
        {
            var orders =await _context.Orders.ToListAsync();

            return orders;
        }

        public async Task<Order> GetOrder(int id)
        {
            var order= await _context.Orders.FindAsync(id);
            
            if(order == null)
            {
                return null;
            }
            else

                return order;
        }
        public async Task UpdateOrder(int id, Order ModfiedOrder)
        {
            var order = await _context.Orders.FindAsync(id);

            if (order != null)
            {
                order.Id = ModfiedOrder.Id;
                order.NumberOfProducts = ModfiedOrder.NumberOfProducts;
                order.ArrivalDate = ModfiedOrder.ArrivalDate;
                order.OrderDate = ModfiedOrder.OrderDate;
                order.NumberOfProducts= ModfiedOrder.NumberOfProducts;
                order.Customer = ModfiedOrder.Customer;
                order.PaymentValue = ModfiedOrder.PaymentValue;
                order.Products=ModfiedOrder.Products;

                _context.Orders.Update(order);

                await _context.SaveChangesAsync();
            }
        }
        public async Task DeleteOrder(int id)
        {
            var order= await _context.Orders.FindAsync(id);

            if (order != null)
            {
                _context.Orders.Remove(order);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<int> AddOrder(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            return order.Id;
        }
    }
}

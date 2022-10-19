using AdonaPerfuma.DB;
using AdonaPerfuma.Interfaces;
using AdonaPerfuma.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdonaPerfuma.Repositories
{
    public class OrderRepo : IOrderRepo
    {
        private readonly PerfumaContext _context;

        public OrderRepo(PerfumaContext context)
        {
            _context = context;
        }


        public async Task<List<Order>> GetAllOrders()
        {
            var orders = await _context.Orders.ToListAsync();

            return orders;
        }

        public async Task<Order> GetOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);

            if (order == null)
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
                order.NumberOfProducts = ModfiedOrder.NumberOfProducts;
                order.ArrivalDate = ModfiedOrder.ArrivalDate;
                order.OrderDate = ModfiedOrder.OrderDate;
                order.NumberOfProducts = ModfiedOrder.NumberOfProducts;
                order.Customer = ModfiedOrder.Customer;
                order.PaymentValue = ModfiedOrder.PaymentValue;
                order.Products = ModfiedOrder.Products;

                _context.Orders.Update(order);

                await _context.SaveChangesAsync();
            }
        }
        public async Task DeleteOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);

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

            if (order.Id > 0)
            {
                return order.Id;
            }
            else
                return 0;
        }

        public async Task<object> GetAllCustomerOrders(int id)
        {
            var getOrders = await _context.Orders.Where(order=>order.Customer.User.Id==id).ToListAsync();   
          

            getOrders.ForEach( order =>
            {
                order.Products = (from products in _context.Products
                                      join OrderProducts in _context.OrderProduct on products.Barcode equals OrderProducts.ProductBarcode
                                      join Orders in _context.Orders on OrderProducts.OrderId equals order.Id
                                      select products).Distinct().ToList();
               
            });

            if (getOrders != null)
            {
                return getOrders;
            }
            else
            {
                return null;
            }
        }
    }
}

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


        public async Task<object> GetAllOrders()
        {
            var orders = await (from Orders in _context.Orders
                                join customer in _context.Customers on Orders.Customer.Id equals customer.Id
                                select new
                                {

                                    Id = Orders.Id,
                                    PaymentValue = Orders.PaymentValue,
                                    ArrivalDate = Orders.ArrivalDate,
                                    OrderDate = Orders.OrderDate,
                                    Customer = Orders.Customer,
                                    NumberOfProducts = Orders.NumberOfProducts,
                                    Products = Orders.Products

                                }).ToListAsync();


            if (orders != null)
            {
                return orders;
            }

            return null;
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
        public async Task UpdateOrder(int id, Order modifiedOrder)
        {
            var getOrder = await (_context.Orders.FindAsync(id));


            if (getOrder != null)
            {
                getOrder.NumberOfProducts = modifiedOrder.NumberOfProducts;
                getOrder.ArrivalDate = modifiedOrder.ArrivalDate;
                getOrder.OrderDate = modifiedOrder.OrderDate;
                getOrder.Customer = modifiedOrder.Customer;
                getOrder.PaymentValue = modifiedOrder.PaymentValue;
                getOrder.Products = (from product in modifiedOrder.Products
                                     join products in _context.Products on product.Barcode equals products.Barcode
                                     join orderProducts in _context.OrderProduct on products.Barcode equals orderProducts.ProductBarcode
                                     join orders in _context.Orders on orderProducts.OrderId equals orders.Id
                                     select products).ToList();

                _context.Orders.Update(getOrder);

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
            var getOrders = await _context.Orders.Where(order => order.Customer.User.Id == id).ToListAsync();


            getOrders.ForEach(order =>
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

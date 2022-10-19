using AdonaPerfuma.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdonaPerfuma.Interfaces
{
    public interface IOrderRepo
    {
        Task<object> GetAllCustomerOrders(int id);
        Task<List<Order>> GetAllOrders();
        Task<Order> GetOrder(int id);
        Task<int> AddOrder(Order order);
        Task UpdateOrder(int id, Order ModfiedOrder);
        Task DeleteOrder(int id);
    }
}

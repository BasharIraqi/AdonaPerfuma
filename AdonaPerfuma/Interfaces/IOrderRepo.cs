using AdonaPerfuma.Models;
using System.Threading.Tasks;

namespace AdonaPerfuma.Interfaces
{
    public interface IOrderRepo
    {
        Task<object> GetAllCustomerOrders(int id);
        Task<object> GetAllOrders();
        Task<Order> GetOrder(int id);
        Task<int> AddOrder(Order order);
        Task UpdateOrder(int id, Order ModfiedOrder);
        Task DeleteOrder(int id);
    }
}

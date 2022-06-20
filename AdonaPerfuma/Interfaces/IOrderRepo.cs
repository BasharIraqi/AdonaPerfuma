using AdonaPerfuma.Models;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdonaPerfuma.Interfaces
{
    public interface IOrderRepo
    {
        Task<List<Order>> GetAllOrders();
        Task<Order> GetOrder(int id);
        Task<int> AddOrder(Order order);
        Task UpdateOrder(int id, Order ModfiedOrder);
        Task DeleteOrder(int id);
    }
}

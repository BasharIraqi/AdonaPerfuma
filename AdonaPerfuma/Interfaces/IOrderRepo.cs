using AdonaPerfuma.Models;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdonaPerfuma.Interfaces
{
    public interface IOrderRepo
    {
        public Task<List<Order>> GetAllOrders();
        public Task<Order> GetOrder(int id);
        public Task<int> AddOrder(Order order);
        public Task UpdateOrder(int id, Order ModfiedOrder);
        public Task DeleteOrder(int id);
    }
}

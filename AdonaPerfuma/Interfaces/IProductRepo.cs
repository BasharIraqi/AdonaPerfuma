using AdonaPerfuma.Models;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdonaPerfuma.Interfaces
{
    public interface IProductRepo
    {
        public Task<List<Product>> GetProducts();
        public Task<Product> GetProductById(int id);

        public Task<int> AddProduct(Product product);

        public Task UpdateProduct(int id,Product modifiedProduct);

        public Task DeleteProduct(int id);
    }
}

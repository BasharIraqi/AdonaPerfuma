using AdonaPerfuma.Models;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdonaPerfuma.Interfaces
{
    public interface IProductRepo
    {
         Task<List<Product>> GetAllProducts();
         Task<Product> GetProductById(int id);

         Task AddProduct(Product product);

         Task UpdateProduct(int id,Product modifiedProduct);

         Task DeleteProduct(int id);
    }
}

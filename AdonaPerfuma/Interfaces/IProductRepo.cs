using AdonaPerfuma.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdonaPerfuma.Interfaces
{
    public interface IProductRepo
    {
         Task<List<Product>> GetAllProducts();
         Task<Product> GetProductById(long id);
        
         Task AddProduct(Product product);

         Task UpdateProduct(long id,Product modifiedProduct);

         Task DeleteProduct(long id);
    }
}

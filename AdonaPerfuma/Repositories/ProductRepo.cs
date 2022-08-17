using AdonaPerfuma.DB;
using AdonaPerfuma.Interfaces;
using AdonaPerfuma.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdonaPerfuma.Repositories
{
    public class ProductRepo : IProductRepo
    {
        private readonly PerfumaContext _context;

        public ProductRepo(PerfumaContext context)
        {
            _context = context;
        }
        public async Task<List<Categories>> GetAllProductsCategories()
        {
           var categories= await _context.Products.Select(p=>p.Category).Distinct().ToListAsync();

            if(categories!=null)
            {
                return categories;
            }
            return null;

        }
        public async Task AddProduct(Product product)
        {
           await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }
        
        public async Task DeleteProduct(long id)
        {
            var product=await _context.Products.FindAsync(id);

            if(product!=null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Product> GetProductById(long id)
        {
            var product =await _context.Products.FindAsync(id);

            if(product!=null)
            {
                return product;
            }
            return null;
        }

        public async Task<List<Product>> GetAllProducts()
        {
            var products = await _context.Products.ToListAsync();
            
            if (products != null)
            {
                return products;
            }

            return null;
        }
        public async Task<List<string>> GetAllProductsBrands()
        {
            var products = await _context.Products.Select(p=>p.Name).Distinct().ToListAsync();

            if (products != null)
            {
                return products;
            }

            return null;
        }
        public async Task UpdateProduct(long id, Product modifiedProduct)
        {
            var product = await _context.Products.FindAsync(id);

            if(product!=null)
            {
              product.Stock = modifiedProduct.Stock;
              product.Barcode=modifiedProduct.Barcode;
              product.Name=modifiedProduct.Name;
              product.IsInStock=modifiedProduct.IsInStock;
              
              _context.Products.Update(product);

                await _context.SaveChangesAsync();
            }
        }
    }
}

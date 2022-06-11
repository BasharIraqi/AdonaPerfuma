using AdonaPerfuma.DB;
using AdonaPerfuma.Interfaces;
using AdonaPerfuma.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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
        public async Task<int> AddProduct(Product product)
        {
           await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return product.Barcode;

        }

        public async Task DeleteProduct(int id)
        {
            var product=await _context.Products.FindAsync(id);

            if(product!=null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Product> GetProductById(int id)
        {
            var product =await _context.Products.FindAsync(id);

            if(product!=null)
            {
                return product;
            }
            return null;
        }

        public async Task<List<Product>> GetProducts()
        {
            var products = await _context.Products.ToListAsync();

            return products;
        }

        public async Task UpdateProduct(int id, Product modifiedProduct)
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

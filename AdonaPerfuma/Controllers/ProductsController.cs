using AdonaPerfuma.Interfaces;
using AdonaPerfuma.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AdonaPerfuma.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepo _repo;
        public ProductsController(IProductRepo repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _repo.GetAllProducts();
            
            if(products == null)
            {
                return NotFound();
            }
            return Ok(products);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct([FromRoute] long id)
        {
            var product = await _repo.GetProductById(id);
            if(product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        //[Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> AddProduct([FromBody] Product product)
        {
            await _repo.AddProduct(product);

            return Ok();
        }

        [HttpPut("{id}")]
        //[Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> UpdateProduct([FromRoute] long id, [FromBody] Product modifiedProduct)
        {
            await _repo.UpdateProduct(id, modifiedProduct);
           
            return Ok();
        }

        [HttpDelete("{id}")]
        //[Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> DeleteProduct(long id)
        {
           var product=await _repo.GetProductById(id);
            if(product==null)
            {
                return NotFound();
            }
            return Ok();
        }


    }
}

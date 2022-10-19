using AdonaPerfuma.Interfaces;
using AdonaPerfuma.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AdonaPerfuma.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderRepo _repo;

        public OrdersController(IOrderRepo repo)
        {
            _repo = repo;
        }

        [HttpGet("customerOrders/{id}")]
        public async Task<IActionResult> GetAllCustomerOrders(int id)
        {
          var orders = await _repo.GetAllCustomerOrders(id);
            if(orders!=null)
            {
                return Ok(orders);
            }
            return NotFound();
        }

        [HttpGet]
       // [Authorize(Roles = "Admin,Manager,General")]
        public async  Task<IActionResult> GetOrders()
        {
            var orders = await _repo.GetAllOrders();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        //[Authorize(Roles = "Admin,Manager,General,Customer")]
        public async Task<IActionResult> GetOrder([FromRoute] int id)
        {
            var order = await _repo.GetOrder(id);

            if (order == null)
                return NotFound();
            return Ok(order);
        }

        [HttpPut("{id}")]
        //[Authorize(Roles = "Customer")]
        public async Task<IActionResult> UpdateOrder([FromRoute] int id, [FromBody] Order modifiedOrder)
        {
            await _repo.UpdateOrder(id, modifiedOrder);
            return Ok();
        }

        [HttpDelete("{id}")]
        //[Authorize(Roles ="customer")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            await _repo.DeleteOrder(id);
            return Ok();
        }

        [HttpPost]
        //[Authorize(Roles ="Customer")]
        public async Task<IActionResult> AddOrder(Order order)
        {
            var id = await _repo.AddOrder(order);

            if (id == 0) 
            {
                return NotFound();
            }
            
           return Ok(id);

        }

    }
}

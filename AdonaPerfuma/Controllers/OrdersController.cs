using AdonaPerfuma.Interfaces;
using AdonaPerfuma.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AdonaPerfuma.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderRepo _repo;

        public OrdersController(IOrderRepo repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async  Task<IActionResult> GetOrders()
        {
            var orders = await _repo.GetAllOrders();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrder(int id)
        {
            var order = await _repo.GetOrder(id);

            if (order == null)
                return NotFound();
            return Ok(order);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder([FromRoute] int id, [FromBody] Order modifiedOrder)
        {
            await _repo.UpdateOrder(id, modifiedOrder);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            await _repo.DeleteOrder(id);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> AddOrder([FromBody]Order order)
        {
            var id = await _repo.AddOrder(order);
           
            return CreatedAtAction(nameof(GetOrder), new {id=id,controller="orders"},id);
        }

    }
}

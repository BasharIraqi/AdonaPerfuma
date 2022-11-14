using AdonaPerfuma.Interfaces;
using AdonaPerfuma.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AdonaPerfuma.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CustomersController : ControllerBase
    {
        private readonly ICustomerRepo _repo;

        public CustomersController(ICustomerRepo repo)
        {
            _repo = repo;
        }
        [HttpGet]
        [Authorize(Roles = "Admin,Manager,General")]
        public async Task<IActionResult> GetAllCustomers()
        {
            var customers = await _repo.GetCustomers();
            return Ok(customers);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,Manager,General,Customer")]
        public async Task<IActionResult> GetCustomer([FromRoute] int id)
        {
            var customer = await _repo.GetCustomer(id);
            return Ok(customer);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,Manager,General,Customer")]
        public async Task<IActionResult> UpdateCustomer([FromRoute] int id, [FromBody] Customer customer)
        {
            await _repo.UpdateCustomer(id, customer);

            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin,Manager,General")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            await _repo.DeleteCustomer(id);
            return Ok();

        }


        [HttpPost]
        
        public async Task<IActionResult> AddCustomer([FromBody] Customer customer)
        {
            var isCustomerExist = await _repo.AddCustomer(customer);

            return Ok(isCustomerExist);
        }

        [HttpGet("GetCustomerByUserId/{id}")]
        [Authorize(Roles="Customer")]
        public async Task<IActionResult> GetCustomerByUserId([FromRoute] int id)
        {
            var customer = await _repo.GetCustomerByUserId(id);

            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);

        }


    }

}

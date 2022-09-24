using AdonaPerfuma.Interfaces;
using AdonaPerfuma.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AdonaPerfuma.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles ="Admin,Manager")]
    public class AddressesController : ControllerBase
    {
        private readonly IAddressRepo _repo;

        public AddressesController(IAddressRepo repo)
        {
            _repo = repo;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAddress([FromRoute]int id)
        {
            var address =await _repo.GetAddressById(id);
            if (address == null)
                return NotFound();
            else
                return Ok(address);
        }
        [HttpPost]
        public async Task<IActionResult> AddAddress(Address address)
        {
            var id= await _repo.AddAddress(address);
            return Ok(id);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAddress(int id)
        {
            await _repo.DeleteAddress(id);
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAddress([FromRoute] int id, [FromBody] Address modifiedAddress)
        {
             await _repo.UpdateAddress(id, modifiedAddress);
            return Ok();
        }
    }
}

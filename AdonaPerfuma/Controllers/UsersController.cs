using AdonaPerfuma.Interfaces;
using AdonaPerfuma.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AdonaPerfuma.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepo _repo;

        public UsersController(IUserRepo repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public async Task<IActionResult> SetUser([FromBody] User user)
        {
            var res =await _repo.SetUser(user);
           
            if(res!=null)
            {
                return Ok();
            }
            return NotFound();
        }
        [HttpGet]
        public async Task<IActionResult> GetUser([FromQuery] string email, [FromQuery] string password)
        {
            var get = await _repo.GetUser(email,password);
            if (get!=null)
            {
                return Ok();
            }
            return Unauthorized();
        }
      
    }
}

using AdonaPerfuma.Interfaces;
using AdonaPerfuma.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;

namespace AdonaPerfuma.Controllers
{
    //[Authorize]
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
    
         
             var res =await _repo.AddUser(user); 
                if(res)
                {
                return Ok(user);
                }
            
          
                return BadRequest();

        }
        [HttpGet("{email}")]
        public async Task<IActionResult> GetUser([FromRoute] string email)
        {
            var get = await _repo.GetUser(email);
            if (get!=null)
            {
                return Ok(get);
            }
            return Unauthorized();
        }
      
    }
}

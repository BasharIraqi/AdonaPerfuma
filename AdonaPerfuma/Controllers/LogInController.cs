using AdonaPerfuma.Interfaces;
using AdonaPerfuma.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AdonaPerfuma.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogInController : ControllerBase
    {

        private readonly ILogIn _repo;

        public LogInController(ILogIn repo)
        {
            _repo = repo;

        }



        [HttpPost]
        public async Task<IActionResult> LogIn([FromBody] LogIn user)
        {
            var res = await _repo.SignIn(user);

            if (string.IsNullOrEmpty(res))
            {
                return Unauthorized();
            }
            return Ok(new { token = res });

        }
    }
}

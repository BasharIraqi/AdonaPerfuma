using AdonaPerfuma.Interfaces;
using AdonaPerfuma.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System.IO;
using System.Linq;
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
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> SetUser([FromBody] User user)
        {
            var res = await _repo.AddUser(user);
            if (res)
            {
                return Ok(user);
            }
            return BadRequest();
        }

        [HttpGet("{email}/{password}")]
        public async Task<IActionResult> GetUser([FromRoute] string email,string password)
        {
            var user = await _repo.GetUser(email,password);
            if (user != null)
            {
                return Ok(user);
            }
            return Unauthorized();
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _repo.GetUsers();
            if (users != null)
            {
                return Ok(users);
            }
            return NotFound();
        }

        [HttpPost("upload"), DisableRequestSizeLimit]
        public async Task<IActionResult> Upload()
        {
            var formCollection = await Request.ReadFormAsync();
            var file = formCollection.Files[0];
            var folderName = Path.Combine("Resources", "Images");
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            if (file.Length > 0)
            {
                var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim().ToString();
                var fullPath = Path.Combine(pathToSave, fileName);
                var dbPath = Path.Combine(folderName, fileName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                return Ok(new { dbPath });
            }
            else
            {
                return BadRequest();
            }

        }


    }
}

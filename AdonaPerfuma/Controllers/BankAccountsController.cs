using AdonaPerfuma.Interfaces;
using AdonaPerfuma.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AdonaPerfuma.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class BankAccountsController : ControllerBase
    {
        private readonly IBankAccountRepo _repo;

        public BankAccountsController(IBankAccountRepo repo)
        {
            _repo = repo;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAccounts()
        {
            var accounts = await _repo.GetAccounts();
            return Ok(accounts);
        }

        [HttpGet("{number}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAccount([FromRoute] int number)
        {
            var account =await _repo.GetAccountById(number);
            if(account == null)
                return NotFound();
            return Ok(account);  
        }

        [HttpDelete("{number}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteAccount([FromRoute] int number)
        {
            await _repo.DeleteAccount(number);
            return Ok();
        }

        [HttpPut("{number}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateAccount([FromRoute] int number, [FromBody] BankAccount ModifiedAccount)
        {
            await _repo.UpdateAccount(number, ModifiedAccount);
            return Ok();
        }
    }
}

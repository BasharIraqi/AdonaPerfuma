using AdonaPerfuma.Interfaces;
using AdonaPerfuma.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AdonaPerfuma.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles ="Admin")]
    public class BankAccountsController : ControllerBase
    {
        private readonly IBankAccountRepo _repo;

        public BankAccountsController(IBankAccountRepo repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAccounts()
        {
            var accounts = await _repo.GetAccounts();
            return Ok(accounts);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAccount(int id)
        {
            var account =await _repo.GetAccountById(id);
            if(account == null)
                return NotFound();
            return Ok(account);  
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccount(int id)
        {
            await _repo.DeleteAccount(id);
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAccount([FromRoute] int id, [FromBody] BankAccount ModifiedAccount)
        {
            await _repo.UpdateAccount(id,ModifiedAccount);
            return Ok();
        }
    }
}

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
    [Authorize(Roles ="Admin")]
    public class CreditCardsController : ControllerBase
    {
        private readonly ICreditCardRepo _repo;

        public CreditCardsController(ICreditCardRepo repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCards()
        {
            var cards = await _repo.GetAllCards();
            return Ok(cards);
        }
        [HttpGet("{cardNumber}")]
        public async Task<IActionResult> GetCard(int cardNumber)
        {
            var card = await _repo.GetCreditCardByNumber(cardNumber);
            return Ok(card);
        }
        [HttpDelete("{cardNmber}")]
        public async Task<IActionResult> DeleteCard(int cardNmber)
        {
           await _repo.DeleteCreditCard(cardNmber);
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> AddCard(CreditCard card)
        {
            await _repo.AddCreditCard(card);
            return Ok();
        }
    }
}

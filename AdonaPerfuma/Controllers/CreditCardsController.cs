using AdonaPerfuma.Interfaces;
using AdonaPerfuma.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Numerics;
using System.Threading.Tasks;

namespace AdonaPerfuma.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles ="Admin")]
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
        public async Task<IActionResult> GetCard([FromRoute] long cardNumber)
        {
            var card = await _repo.GetCreditCardByNumber(cardNumber);
            return Ok(card);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCard(int id)
        {
           await _repo.DeleteCreditCard(id);
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> AddCard(CreditCard card)
        {
          var id= await _repo.AddCreditCard(card);

            if(id!=-1)
           return Ok(id);

            else
                return NoContent();
        }
    }
}

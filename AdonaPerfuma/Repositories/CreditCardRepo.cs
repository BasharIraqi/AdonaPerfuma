using AdonaPerfuma.DB;
using AdonaPerfuma.Interfaces;
using AdonaPerfuma.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Threading.Tasks;


namespace AdonaPerfuma.Repositories
{
    public class CreditCardRepo : ICreditCardRepo
    {
        private readonly PerfumaContext _context;

        public CreditCardRepo(PerfumaContext context)
        {
            _context = context;
        }
        public async Task<int> AddCreditCard(CreditCard creditCard)
        {
            var IsCardExist=await _context.CreditCards.FindAsync(creditCard.Number);

            if (IsCardExist == null)
            {
            await _context.CreditCards.AddAsync(creditCard);
            await _context.SaveChangesAsync();
            return creditCard.Id;
            }

            else
            return -1;
        }

        public async Task DeleteCreditCard(int id)
        {
            var creditCard =await _context.CreditCards.FindAsync(id);
            if (creditCard != null)
            {
                _context.CreditCards.Remove(creditCard);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<CreditCard>> GetAllCards()
        {
            var creditCards =await _context.CreditCards.ToListAsync();
            return creditCards;
        }

        public async Task<CreditCard> GetCreditCardByNumber(long number)
        {
            var creditCard = await _context.CreditCards.FindAsync(number);
            if (creditCard != null)
            {
                return creditCard;
            }
            else
                return null;
        }
    }
}

using AdonaPerfuma.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdonaPerfuma.Interfaces
{
    public interface ICreditCardRepo
    {
        public Task<List<CreditCard>> GetAllCards();

        public Task<CreditCard> GetCreditCardByNumber(int number);

        public Task<int> AddCreditCard(CreditCard creditCard);

        public Task DeleteCreditCard(int id);
    }
}

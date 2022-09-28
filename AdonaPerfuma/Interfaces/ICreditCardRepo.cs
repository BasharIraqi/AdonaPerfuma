using AdonaPerfuma.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdonaPerfuma.Interfaces
{
    public interface ICreditCardRepo
    {
        Task<List<CreditCard>> GetAllCards();

        Task<CreditCard> GetCreditCardByNumber(long number);

        Task<int> AddCreditCard(CreditCard creditCard);

        Task DeleteCreditCard(int id);
    }
}

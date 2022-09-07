using AdonaPerfuma.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdonaPerfuma.Interfaces
{
    public interface ICreditCardRepo
    {
        Task<List<CreditCard>> GetAllCards();

        Task<CreditCard> GetCreditCardByNumber(long number);

        Task<long> AddCreditCard(CreditCard creditCard);

        Task DeleteCreditCard(long id);
    }
}

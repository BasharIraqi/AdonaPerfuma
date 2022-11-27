using AdonaPerfuma.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdonaPerfuma.Interfaces
{
    public interface IBankAccountRepo
    {
        Task<List<BankAccount>> GetAccounts();

        Task<BankAccount> GetAccountById(int number);

        Task AddAccount(BankAccount bankAccount);

        Task UpdateAccount(int number,BankAccount modifiedAccount);

        Task DeleteAccount(int number);
    }
}

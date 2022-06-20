using AdonaPerfuma.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdonaPerfuma.Interfaces
{
    public interface IBankAccountRepo
    {
        Task<List<BankAccount>> GetAccounts();

        Task<BankAccount> GetAccountById(int id);

        Task AddAccount(BankAccount bankAccount);

        Task UpdateAccount(int id,BankAccount modifiedAccount);

        Task DeleteAccount(int id);
    }
}

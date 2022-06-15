using AdonaPerfuma.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdonaPerfuma.Interfaces
{
    public interface IBankAccountRepo
    {
        public Task<List<BankAccount>> GetAccounts();

        public Task<BankAccount> GetAccountById(int id);

        public Task AddAccount(BankAccount bankAccount);

        public Task UpdateAccount(int id,BankAccount modifiedAccount);

        public Task DeleteAccount(int id);
    }
}

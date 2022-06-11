using AdonaPerfuma.Models;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdonaPerfuma.Interfaces
{
    public interface IBankAccountRepo
    {
        public Task<List<BankAccount>> GetAccounts();

        public Task<BankAccount> GetAccountById(int id);

        public Task<int> AddAccount(BankAccount bankAccount);

        public Task UpdateAccount(int id,BankAccount modifiedAccount);

        public Task DeleteAccount(int id);
    }
}

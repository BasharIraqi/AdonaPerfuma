using AdonaPerfuma.DB;
using AdonaPerfuma.Interfaces;
using AdonaPerfuma.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdonaPerfuma.Repositories
{
    public class BankAccountRepo : IBankAccountRepo
    {
        private readonly PerfumaContext _context;

        public BankAccountRepo(PerfumaContext context)
        {
            _context = context;
        }
        public  async Task AddAccount(BankAccount bankAccount)
        {
            await _context.BankAccounts.AddAsync(bankAccount);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAccount(int id)
        {
            var bankAccount = await _context.BankAccounts.FindAsync(id);
            if (bankAccount != null)
            {
                _context.BankAccounts.Remove(bankAccount);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<BankAccount> GetAccountById(int id)
        {
            var bankAccount =await _context.BankAccounts.FindAsync(id);
            if (bankAccount != null)
            {
                return bankAccount;
            }
            else
                return null;
        }

        public async Task<List<BankAccount>> GetAccounts()
        {
            var bankAccounts = await _context.BankAccounts.ToListAsync();
            return bankAccounts;
        }

        public async Task UpdateAccount(int id, BankAccount modifiedAccount)
        {
            var bankAccount =await _context.BankAccounts.FindAsync(id);
            if(bankAccount!=null)
            {
                bankAccount.AccountNumber = modifiedAccount.AccountNumber;
                bankAccount.BranchNumber = modifiedAccount.BranchNumber;
                bankAccount.Name = modifiedAccount.Name;
                bankAccount.FirstName = modifiedAccount.FirstName;
                bankAccount.LastName = modifiedAccount.LastName;

                _context.BankAccounts.Update(bankAccount);
                await _context.SaveChangesAsync();
                
            }
        }
    }
}

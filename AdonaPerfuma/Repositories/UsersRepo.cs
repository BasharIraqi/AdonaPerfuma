using AdonaPerfuma.DB;
using AdonaPerfuma.Interfaces;
using AdonaPerfuma.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AdonaPerfuma.Repositories
{
    public class UsersRepo : IUserRepo
    {
        private readonly PerfumaContext _context;
        public UsersRepo(PerfumaContext context)
        {
            _context = context;
        }

        public async Task<User> GetUser(string email, string password)
        {
            var find = await _context.AspNetUsers.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
            if (find != null)
            {
                return find;
            }
            return null;
        }
        
        public async Task<User> SetUser(User user)
        {
            var find = await _context.AspNetUsers.FindAsync(user);
            if (find == null)
            {
                _context.AspNetUsers.Add(user);
                await _context.SaveChangesAsync();
                return find;
            }
            return null;
        }
    }
}

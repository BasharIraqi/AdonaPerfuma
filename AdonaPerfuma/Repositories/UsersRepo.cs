using AdonaPerfuma.DB;
using AdonaPerfuma.Interfaces;
using AdonaPerfuma.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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
        public async Task<bool> AddUser(User user)
        {
            var check =await GetUser(user.Email);

            if(check == null)
            {
                 await _context.Users.AddAsync(user);
                 await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteUser(string email)
        {
            var user=await _context.Users.FindAsync(email);

            if(user==null)
            {
                return false;
            }
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Image> GetImage(int id)
        {
           var getImage=await _context.Image.FindAsync(id);

            if(getImage==null)
            {
                return null;
            }
            return getImage;
        }

        public async Task<User> GetUser(string email)
        {
            var find = await _context.Users.FirstOrDefaultAsync(u => u.Email == email );
            if (find != null)
            {
                return find;
            }
            return null;
        }

        public async Task<List<User>> GetUsers()
        {
           var users=await _context.Users.ToListAsync();
            return users;
        }

        public async Task<bool> UpdateUser(int id,User modifiedUser)
        {
            var user = await _context.Users.FindAsync(id);
             
            if(user!=null)
            {
               user.FirstName = modifiedUser.FirstName;
               user.LastName = modifiedUser.LastName;
               user.Email = modifiedUser.Email;
               user.Password = modifiedUser.Password;
               user.ConfirmPassword=modifiedUser.ConfirmPassword;
               user.Role=modifiedUser.Role;
               user.Image.Path = modifiedUser.Image.Path; 

                 _context.Users.Update(user);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}

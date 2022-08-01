using AdonaPerfuma.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdonaPerfuma.Interfaces
{
    public interface IUserRepo
    {
        Task<List<User>> GetUsers();
        Task<User> GetUser(string email,string password);
        Task<bool> AddUser(User user);
        Task<bool> UpdateUser(int id,User user);
        Task<bool> DeleteUser(string email);



    }
}

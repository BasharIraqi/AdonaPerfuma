using AdonaPerfuma.Models;
using System.Threading.Tasks;

namespace AdonaPerfuma.Interfaces
{
    public interface IUserRepo
    {
        Task<User> GetUser(string email,string password);

        Task<User> SetUser(User user);


    }
}

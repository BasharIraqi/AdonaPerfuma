using AdonaPerfuma.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdonaPerfuma.Interfaces
{
    public abstract class IUserRepo
    {
        public abstract Task<List<User>> GetUsers();
        public abstract Task<User> GetUserById(int id);

        public abstract Task<int> AddUser(User user);

        public abstract Task UpdateUser(int id, User modifiedUser);

        public abstract Task DeleteUser(int id);
    }
}

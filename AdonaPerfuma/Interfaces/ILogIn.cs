using AdonaPerfuma.Models;
using System.Threading.Tasks;

namespace AdonaPerfuma.Interfaces
{
    public interface ILogIn
    {
        Task<string> SignIn(LogIn user);
    }
}

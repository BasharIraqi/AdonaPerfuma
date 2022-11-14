using AdonaPerfuma.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AdonaPerfuma.Interfaces
{
    public interface ILogIn
    {
        Task<string> SignIn(LogIn user);
    }
}

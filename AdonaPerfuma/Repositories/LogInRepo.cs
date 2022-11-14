using AdonaPerfuma.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System;
using AdonaPerfuma.DB;
using Microsoft.Extensions.Configuration;
using AdonaPerfuma.Interfaces;

namespace AdonaPerfuma.Repositories
{
    public class LogInRepo : ILogIn
    {
        private readonly PerfumaContext _context;
        private readonly IConfiguration _configuration;


        public LogInRepo(PerfumaContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<string> SignIn(LogIn user)
        {
            var getUser = await _context.Users.FirstOrDefaultAsync(u => user.Email == u.Email && user.Password == u.Password);

            if (getUser == null)
            {
                return null;
            }
            else
            {

                var myClaim = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                    new Claim(ClaimTypes.Role,getUser.Role.ToString())
                };

                var authSignKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["JWT:Secret"]));

                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.UtcNow.AddDays(1),
                    claims: myClaim,
                    signingCredentials: new SigningCredentials(authSignKey, SecurityAlgorithms.HmacSha256Signature)
                    );

                return new JwtSecurityTokenHandler().WriteToken(token);
            }
        }
    }
}

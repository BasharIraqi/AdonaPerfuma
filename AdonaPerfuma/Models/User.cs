using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace AdonaPerfuma.Models
{
    public class User :IdentityUser
    {
        [Required]
        [EmailAddress]
        public override string Email { get; set; }

        [Required]
        [Range(8,16)]
        public string Password { get; set; }
    }
}

   
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace AdonaPerfuma.Models
{
    public class User :IdentityUser
    {
        [Required]
        [EmailAddress]
        [Key]
        public override string Email { get; set; }

        [Required]
        [Range(8,16)]
        [Key]
        public string Password { get; set; }

        [Required]
        public UserTypes UserType { get; set; }
    }
}

    public enum UserTypes
    {
      Admin,
      Manager,
      General,
      Guest,
    }
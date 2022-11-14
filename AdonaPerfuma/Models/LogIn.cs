using System.ComponentModel.DataAnnotations;

namespace AdonaPerfuma.Models
{
    public class LogIn
    {
        [Required]
        [MaxLength(30)]
        public string Email { get; set; }

        [Required]
        [MaxLength(30)]
        public string Password { get; set; }
    }
}

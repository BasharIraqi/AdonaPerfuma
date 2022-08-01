using System.ComponentModel.DataAnnotations;

namespace AdonaPerfuma.Models
{
    public class User 
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(50)]
        public string Email { get; set; }

        [Required]
        [Range(8,16)]
        public string Password { get; set; }

        [Required]
        [Range(8, 16)]
        public string ConfirmPassword { get; set; }

        [Required]
        public Roles Role { get; set; }
    }

    public enum Roles
    {
        Admin,
        Manager,
        General,
        Customer
    }
}

   
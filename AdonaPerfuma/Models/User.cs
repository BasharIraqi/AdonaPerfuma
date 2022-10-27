using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace AdonaPerfuma.Models
{
    public class User 
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(30)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(30)]
        public string Email { get; set; }

        [Required]
        [MinLength(8),MaxLength(16)]
        public string Password { get; set; }

        [Required]
        [MinLength(8),MaxLength(16)]
        public string ConfirmPassword { get; set; }

        [Required]
        public Roles Role { get; set; }

        [AllowNull]
        public string ImagePath { get; set; }

    }

    public enum Roles
    {
        Admin,
        Manager,
        General,
        Customer
    }
}

   
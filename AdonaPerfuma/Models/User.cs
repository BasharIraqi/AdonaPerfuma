using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.IO;

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
        [MinLength(8),MaxLength(16)]
        public string Password { get; set; }

        [Required]
        [MinLength(8),MaxLength(16)]
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

   
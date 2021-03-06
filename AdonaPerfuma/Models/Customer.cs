using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace AdonaPerfuma.Models
{
    public class Customer
    {
        [Required]
        [Range(9,9)]
        public int Id { get; set; }
        
        [Required]
        public string FirstName { get; set; }
        
        [Required]
        public string LastName { get; set; }
        
        public List<Order> Orders { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public int PhoneNumber { get; set; }

        [Required]
        public CreditCard Payment { get; set; }

        [Required]
        public Address Address { get; set; }

        [AllowNull]
        public User User { get; set; }
    }
}
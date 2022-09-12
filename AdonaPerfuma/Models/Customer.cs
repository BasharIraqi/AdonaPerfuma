using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace AdonaPerfuma.Models
{
    public class Customer
    {
        [Required]
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
        public CreditCard CreditCard { get; set; }

        [Required]
        public Address Address { get; set; }

        [Required]
        public User User { get; set; }
    }
}
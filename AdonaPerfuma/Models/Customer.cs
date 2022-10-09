using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AdonaPerfuma.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }
        
        [Required]
        public string LastName { get; set; }
        
        public List<Order> Orders { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
       
        public string PhoneNumber { get; set; }

       
        public CreditCard CreditCard { get; set; }

       
        public Address Address { get; set; }

        [Required]
        public User User { get; set; }
    }
}
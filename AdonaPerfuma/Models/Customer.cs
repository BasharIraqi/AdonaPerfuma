using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AdonaPerfuma.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string FirstName { get; set; }
        
        [Required]
        [MaxLength (30)]
        public string LastName { get; set; }
        
        public List<Order> Orders { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(30)]
        public string Email { get; set; }

        [MaxLength(10)]
        public string PhoneNumber { get; set; }
       
        public CreditCard CreditCard { get; set; }

       
        public Address Address { get; set; }

        [Required]
        public User User { get; set; }
    }
}
using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace AdonaPerfuma.Models
{
    public class CreditCard
    {
        [Required]
        [CreditCard]
        [Key]
        public long Number { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public int Cvv { get; set; }

        [Required]
        public DateTime ExpiredDate { get; set; }

        [AllowNull]
        public int NumberOfPayments { get; set; }

    }
}

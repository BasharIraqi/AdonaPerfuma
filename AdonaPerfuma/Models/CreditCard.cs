using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace AdonaPerfuma.Models
{
    public class CreditCard
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public long Number { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public int Cvv { get; set; }

        [Required]
        public string ExpiredMonth { get; set; }

        [Required]
        public string ExpiredYear { get; set; }

        [AllowNull]
        public int NumberOfPayments { get; set; }

    }
}

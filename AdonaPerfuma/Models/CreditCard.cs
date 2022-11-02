using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace AdonaPerfuma.Models
{
    public class CreditCard
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public long Number { get; set; }

        [Required]
        [MaxLength(30)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(30)]
        public string LastName { get; set; }

        [Required]
        public int Cvv { get; set; }

        [Required]
        [MaxLength(2)]
        public string ExpiredMonth { get; set; }

        [Required]
        [MaxLength(2)]
        public string ExpiredYear { get; set; }

        [AllowNull]
        public int NumberOfPayments { get; set; }

    }
}

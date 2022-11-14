using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace AdonaPerfuma.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Country { get; set; }

        [Required]
        [MaxLength(30)]
        public string City { get; set; }

        [Required]
        [MaxLength (30)]
        public string Street { get; set; }

        [AllowNull]
        [MaxLength(2)]
        public int HouseNumber { get; set; }

        [Required]
        [MaxLength(7)]
        public int PostalCode { get; set; }

    }
}
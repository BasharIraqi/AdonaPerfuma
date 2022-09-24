using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace AdonaPerfuma.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Street { get; set; }

        [AllowNull]
        public int HouseNumber { get; set; }

        [Required]
        public string PostalCode { get; set; }

    }
}
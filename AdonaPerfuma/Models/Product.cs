using System;
using System.ComponentModel.DataAnnotations;

namespace AdonaPerfuma.Models
{
    public class Product
    {
        [Required]
        [Key]
        [Range(6, 16)]
        public long Barcode { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int Stock { get; set; }

        [Required]
        public bool IsInStock { get; set; }

        [Required]
        public string ImageUrl { get; set; }
        
        [Required]
        public double Price { get; set; }

        public Categories Category { get; set; }

    }

    public enum Categories
    {
        MenPerfumes,
        WomenPerfumes,
        UnisexPerfumes,
        MenBoutiqePerfumes,
        WomenBoutiqePerfumes,
        UnisexBoutiqePerfumes,
        MenSet,
        WomenSet
    }
}

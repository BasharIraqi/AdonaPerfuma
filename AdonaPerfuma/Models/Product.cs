using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace AdonaPerfuma.Models
{
    public class Product
    {
        [Key]
        [Range(6, 13)]
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

        [Required]
        public Categories Category { get; set; }

        [Required]
        public string Review { get; set; }

        public  List<Order> orders{ get; set; }

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

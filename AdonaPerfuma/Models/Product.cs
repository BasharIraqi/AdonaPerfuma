using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AdonaPerfuma.Models
{
    public class Product
    {
        [Key]
        public long Barcode { get; set; }

        [Required]
        [MaxLength(30)]
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

        public  ICollection<Order> Orders{ get; set; }

        public List<OrderProduct> OrderProducts { get; set; }

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

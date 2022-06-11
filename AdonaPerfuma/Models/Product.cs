using System.ComponentModel.DataAnnotations;

namespace AdonaPerfuma.Models
{
    public class Product
    {
        [Required]
        [Key]
        [Range(6,12)]
        public int Barcode { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Stock { get; set; }

        [Required]
        public bool IsInStock 
        {
            get
            {
                return IsInStock;
            }
            set {
                if (Stock == 0)
                    IsInStock = false;
                else
                    IsInStock = true;
            }
        }
    }
}

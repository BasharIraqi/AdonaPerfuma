using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AdonaPerfuma.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        public Customer Customer { get; set; }

        public ICollection<Product> Products { get; set; }

        public List<OrderProduct> OrderProducts { get; set; }

        [Required]
        public int NumberOfProducts { get; set; }

        [Required]
        public double PaymentValue { get; set; }

        [Required]
        public string OrderDate { get; set; }

        [Required]
        public string ArrivalDate { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AdonaPerfuma.Models
{
    public class Order
    {
        [Required]
        [Range(4,8)]
        public int Id { get; set; }

        [Required]
        public Customer Customer { get; set; }

        [Required]
        public List<Product> Products { get; set; }

        public int NumberOfProducts { get { return NumberOfProducts; } set {NumberOfProducts= Products.Count; } }

        [DataType(DataType.Currency)]
        public double PaymentValue { get; set; }

        [DataType(DataType.Date)]
        public DateTime OrderDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime ArrivalDate { get; set; }
    }
}

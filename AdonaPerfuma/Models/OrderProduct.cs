namespace AdonaPerfuma.Models
{
    public class OrderProduct
    {
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public long ProductBarcode { get; set; }
        public Product Product { get; set; }
    }
}

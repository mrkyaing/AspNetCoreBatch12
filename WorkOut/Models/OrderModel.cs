namespace WorkOut.Models
{
    public class OrderModel
    {
        public string  OrderId { get; set; }
        public int  Quantity { get; set; }
        public int  UnitPrice { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}

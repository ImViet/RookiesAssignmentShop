namespace RAShop.Backend.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public DateTime DateCreated { get; set; }
        public string ShipAddress { get; set; }
    }
}

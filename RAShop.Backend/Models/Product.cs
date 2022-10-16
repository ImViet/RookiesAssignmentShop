namespace RAShop.Backend.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }  
        public int Quantity { get; set; }
        public string? Description { get; set; }
        public string Origin { get; set; }
        public string Unit { get; set; }    
        public virtual ProductImage? Image { get; set; }
        public virtual Category Category { get; set; }
    }
}

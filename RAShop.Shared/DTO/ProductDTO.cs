using System.ComponentModel.DataAnnotations.Schema;

namespace RAShop.Shared.DTO
{
    public class ProductDTO
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Origin { get; set; }
        public string Unit { get; set; }
        public int CategoryName { get; set; }
        public string MainImg { get; set; }
    }
}

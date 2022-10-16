using System.ComponentModel.DataAnnotations.Schema;

namespace RAShop.Backend.Models
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        [ForeignKey("OrderId")]
        public virtual Order Orders { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product Products { get; set; }
    }
}

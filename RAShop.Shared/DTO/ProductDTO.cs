using System.ComponentModel.DataAnnotations.Schema;

namespace RAShop.Shared.DTO
{
    public class ProductDTO
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public DateTime? DateCreated {get; set;} 
        public DateTime? DateUpdated {get; set;}
        public string? Description { get; set; }
        public string? Origin { get; set; }
        public string? Unit { get; set; }
        public string CategoryName { get; set; }
        public string MainImg { get; set; }
        public IList<RatingDTO>? Ratings {get; set;} = null;

    }
}

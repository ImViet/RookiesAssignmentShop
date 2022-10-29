using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace RAShop.Backend.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        [Required]
        [StringLength(50)]
        public string ProductName { get; set; }
        public decimal Price { get; set; }  
        public int Quantity { get; set; }
        public DateTime? DateCreated {get; set;} 
        public DateTime? DateUpdated {get; set;}
        public string? Description { get; set; }
        public string? Origin { get; set; }
        public string? Unit { get; set; }
        public string? MainImg{get; set;}
        public int? SubCateId { get; set; }
        [ForeignKey("SubCateId")]
        public virtual SubCategory? SubCategory { get; set; }

        public int? CateId { get; set; }
        [ForeignKey("CateId")]
        public virtual Category? Category { get; set; }
        public IList<Rating>? Ratings { get; set; }

    }
}

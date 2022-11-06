using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace RAShop.Backend.Models
{
    public class SubCategory
    {
        public int SubCategoryId { get; set; }
        [Required]
        [StringLength(50)]
        public string SubCategoryName { get; set; }
        public string? SubCategoryImg {get; set;}
        public string? Description { get; set; }
        public int? CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category? Category { get; set; } 
        public IList<Product>? Products { get; set; }
    }
}

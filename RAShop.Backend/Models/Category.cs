using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAShop.Backend.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        [Required]
        [StringLength(50)]
        public string CategoryName { get; set; }
        public string? Description { get; set; }
        public IList<SubCategory> SubCates { get; set; }
        public Category()
        {
            SubCates = new List<SubCategory>();
        }
    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace RAShop.Backend.Models
{
    public class Rating
    {
        public int RatingId { get; set; }
        [Required]
        public int Star { get; set; }
        public string? Comment { get; set; }
        public DateTime DateCreated {get; set;}
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product? Product { get; set; }
    }
}
namespace RAShop.Shared.DTO
{
    public class CreateProductDTO
    {
        public string ProductName { get; set; }
        public decimal Price { get; set; }  
        public DateTime DateCreated {get; set;} = DateTime.Now;
        public DateTime? DateUpdated {get; set;}
        public string? Description { get; set; }
        public string? Origin { get; set; }
        public string? Unit { get; set; }
        public string? MainImg{get; set;}
        public int CategoryId { get; set; }
        public int? SubCategoryId { get; set; }
    }
}
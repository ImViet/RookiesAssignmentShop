namespace RAShop.Shared.DTO
{
    public class CreateProductDTO
    {
        public string ProductName { get; set; }
        public decimal Price { get; set; }  
        public int? Quantity { get; set; }
        public DateTime? DateCreated {get; set;} 
        public DateTime? DateUpdated {get; set;}
        public string? Description { get; set; }
        public string? Origin { get; set; }
        public string? Unit { get; set; }
        public string? MainImg{get; set;}
        public int? SubCateId { get; set; }
        public int? CateId { get; set; }
    }
}
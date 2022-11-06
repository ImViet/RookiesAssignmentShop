namespace RAShop.Shared.DTO
{
    public class CategoryDTO
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public IList<SubCateDTO>? SubCates { get; set; } 
        public IList<ProductDTO>? Products { get; set; }
    }
}

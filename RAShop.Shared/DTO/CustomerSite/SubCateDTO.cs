namespace RAShop.Shared.DTO
{
    public class SubCateDTO
    {
        public int SubCategoryId { get; set; }
        public string SubCategoryName { get; set; } 
        public string CategoryParentId { get; set; } 
        public string CategoryParentName { get; set; } 
        public string Description { get; set; }
        public IList<ProductDTO>? Products{get; set;}

    }
}
namespace RAShop.Shared.DTO
{
    public class CreateSubCategoryDTO
    {
        public string SubCateName { get; set; }
        public string? Description { get; set; }
        public int CategoryId{get; set;}
    }
}
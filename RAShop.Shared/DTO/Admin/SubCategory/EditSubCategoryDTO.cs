namespace RAShop.Shared.DTO
{
    public class EditSubCategoryDTO
    {
        public int SubCateId{get; set;}
        public string SubCateName { get; set; }
        public string? Description { get; set; }
        public int CategoryParentId{get; set;}
    }
}
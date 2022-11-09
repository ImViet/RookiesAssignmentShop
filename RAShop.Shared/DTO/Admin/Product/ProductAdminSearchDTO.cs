namespace RAShop.Shared.DTO
{
    public class ProductAdminSearchDTO
    {
        public string Query {get; set;} ="";
        public string SortOrder {get; set;} ="";
        public int Page { get; set; }
        public int PageSize { get; set; } = 4;
        public int cateId {get; set;}
        public int subCateId {get; set;}
    }
}
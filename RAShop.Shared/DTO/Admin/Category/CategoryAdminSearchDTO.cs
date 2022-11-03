namespace RAShop.Shared.DTO
{
    public class CategoryAdminSearchDTO
    {
        public string Query {get; set;} ="";
        public string SortOrder {get; set;} ="";
        public int Page { get; set; }
        public int PageSize { get; set; } = 4;
    }
}
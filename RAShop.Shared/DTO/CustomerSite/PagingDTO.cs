namespace RAShop.Shared.DTO
{
    public class PagingDTO<T>
    {
        public int TotalPages {get; set;}
        public const int PAGESIZE = 8;
        public List<T>? items {get; set;}
    }
}
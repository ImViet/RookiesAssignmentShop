namespace RAShop.Shared.DTO
{
    public class PagingDTO
    {
        public int TotalPages {get; set;}
        public const int PAGESIZE = 8;
        public List<ProductDTO>? Products {get; set;}
    }
}
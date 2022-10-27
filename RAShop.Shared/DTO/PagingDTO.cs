namespace RAShop.Shared.DTO
{
    public class PagingDTO
    {
        public int TotalPages {get; set;}
        public const int PAGESIZE = 4;
        public List<ProductDTO>? Products {get; set;}
    }
}
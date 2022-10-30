namespace RAShop.Shared.DTO
{
    public class AddRatingDTO
    {
        public int ProductId {get; set;}
        public int Star {get; set;}
        public string? Comment {get; set;}
        public DateTime DateCreated {get; set;}
    }
}
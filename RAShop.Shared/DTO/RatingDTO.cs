namespace RAShop.Shared.DTO
{
    public class RatingDTO
    {
        public int RatingId {get; set;}
        public int Star {get; set;}
        public string? Comment {get; set;}
        public DateTime DateCreated {get; set;}
    }
}
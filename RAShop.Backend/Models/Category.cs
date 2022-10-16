namespace RAShop.Backend.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public IList<Product> Products { get; set; }
        public Category()
        {
            Products = new List<Product>();
        }
    }
}

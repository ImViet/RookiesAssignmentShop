namespace RAShop.Shared.DTO
{
    public class CartDTO
    {
        public int Quantity { get; set; }
        public ProductDTO Product { get; set; }
        public double Total
        {
            get { return Quantity * (double)Product.Price; }
        }
    }
}
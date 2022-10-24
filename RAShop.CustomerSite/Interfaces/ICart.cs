using RAShop.Shared.DTO;

namespace RAShop.CustomerSite.Interfaces
{
    public interface ICart 
    {
        public List<CartDTO>? GetCart();
        public void AddToCart(int productid);
        public void RemoveItem(int productid);
        public void ClearCart();
        public void SaveCartSession(List<CartDTO> lst);
        public int CountItem();
    }
}
using RAShop.Shared.DTO;

namespace RAShop.CustomerSite.Interfaces
{
    public interface ICart 
    {
        List<CartDTO>? GetCart();
        void AddToCart(int productid);
        void RemoveItem(int productid);
        void ClearCart();
        void SaveCartSession(List<CartDTO> lst);
        int CountItem();
    }
}
using RAShop.CustomerSite.Interfaces;
using RAShop.Shared.DTO;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Linq;

namespace RAShop.CustomerSite.Services
{
    public class CartService : ICart
    {
        public const string CARTKEY = "cart";
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IProduct _productService;

        public CartService(IHttpContextAccessor httpContextAccessor, IProduct productService)
        {
            _httpContextAccessor = httpContextAccessor;
            _productService = productService;
        }
        //Lay ra cac san pham trong Cart
        public List<CartDTO> GetCart()
        {
            var session = _httpContextAccessor.HttpContext.Session;
            string jsoncart = session.GetString(CARTKEY);
            if (jsoncart != null)
            {
                //Convert tu json thanh CartDTO
                return JsonConvert.DeserializeObject<List<CartDTO>>(jsoncart);
            }
            return new List<CartDTO>();
        }

        //Xoa Cart
        public void ClearCart()
        {
            var session = _httpContextAccessor.HttpContext.Session;
            session.Remove(CARTKEY);
        }
        //Luu Cart
        public void SaveCartSession (List<CartDTO> lst)
        {
        var session = _httpContextAccessor.HttpContext.Session;
        string jsoncart = JsonConvert.SerializeObject (lst);
        session.SetString (CARTKEY, jsoncart);
        }
          //Them 1 san pham vao Cart
        public void AddToCart(int productid)
        {
            var product = _productService.GetProductDetail(productid);
            var cart = GetCart();
            var cartItem = cart.Find(p => p.Product.ProductId == productid);
            if(cartItem != null)
            {
                cartItem.Quantity++;
            }
            else 
            {
                CartDTO newItem = new CartDTO()
                {
                    Quantity = 1,
                    Product = product
                };
                cart.Add(newItem);
            }
            SaveCartSession(cart);
        }
        public void RemoveItem(int productid)
        {
            var product = _productService.GetProductDetail(productid);
            var cart = GetCart();
            var cartItem = cart.Find(p => p.Product.ProductId == productid);
            cart.Remove(cartItem);
            SaveCartSession(cart);
        }
        public int CountItem()
        {
            if(GetCart().Count() == 0)
                return 0;
            return GetCart().Count;
        }
    }
}
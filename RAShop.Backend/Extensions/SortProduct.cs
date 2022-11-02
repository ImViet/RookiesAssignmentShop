using RAShop.Backend.Models;

namespace RAShop.Backend.Extensions
{
    public static class SortProduct
    {
        public static  IQueryable<Product> Sorting(IQueryable<Product> products, string sortOrder)
        {
            switch (sortOrder)
                {
                    case "price":
                        products = products.OrderBy(p => p.Price);
                        break;
                    case "price_desc":
                        products = products.OrderByDescending(p => p.Price);
                        break;
                    case "name":
                        products = products.OrderBy(p => p.ProductName);
                        break;
                    case "name_desc":
                        products = products.OrderByDescending(p => p.ProductName);
                        break;
                    default:
                        products = products.OrderBy(p => p.ProductId);
                        break;
                }
                return products;
        }
    }
}
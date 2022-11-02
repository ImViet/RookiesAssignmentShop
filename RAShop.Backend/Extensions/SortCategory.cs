using RAShop.Backend.Models;

namespace RAShop.Backend.Extensions
{
    public static class SortCategory
    {
        public static  IQueryable<Category> Sorting(IQueryable<Category> categories, string sortOrder)
        {
            switch (sortOrder)
                {
                    case "name":
                        categories = categories.OrderBy(p => p.CategoryName);
                        break;
                    case "name_desc":
                        categories = categories.OrderByDescending(p => p.CategoryName);
                        break;
                    default:
                        categories = categories.OrderBy(p => p.CategoryId);
                        break;
                }
                return categories;
        }
    }
}
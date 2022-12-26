using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RAShop.CustomerSite.Interfaces;

namespace RAShop.CustomerSite.Pages.Home
{
    public class GetProductByCateIdModel : PageModel
    {
        private readonly IProduct _productService;
        private readonly ICategory _categoryService;
        private readonly ISubCategory _subCategoryService;
        public GetProductByCateIdModel(IProduct productService, ICategory categoryService, ISubCategory subCategoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _subCategoryService = subCategoryService;
        }
        public async Task<IActionResult> OnGetAsync(int cateid, string sortOrder = "0", int pageCurrent = 1)
        {
            if (pageCurrent > 1)
                ViewData["page"] = pageCurrent;
            else
                ViewData["page"] = 1;
            if (sortOrder != "0")
                ViewData["sort"] = sortOrder;
            else
                ViewData["sort"] = "0";
            var data = await _productService.GetProductByCateId(cateid, sortOrder, pageCurrent);
                var temp = data.items.Find(x => x.CategoryId == cateid);
                // ViewData["nameCate"] = temp.CategoryName;
                ViewData["products"] = data.items;
                ViewData["totalPage"] = data.TotalPages;
                ViewData["cateId"] = cateid;
            return Page();
        }
    }
}
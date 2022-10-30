using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RAShop.CustomerSite.Interfaces;

namespace RAShop.CustomerSite.Pages.Home
{
    public class IndexModel: PageModel
    {
        private readonly IProduct _productService;
        private readonly ICategory _categoryService;
        private readonly ISubCategory _subCategoryService;
        public IndexModel(IProduct productService, ICategory categoryService, ISubCategory subCategoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _subCategoryService = subCategoryService;
        }
     public async Task<IActionResult> OnGetAsync()
        {
            ViewData["categories"] = await _categoryService.GetAll();
            ViewData["subcategories"] = await _subCategoryService.GetAll();
            return Page();
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RAShop.CustomerSite.Interfaces;
using RAShop.Shared.DTO;

namespace RAShop.CustomerSite.ViewComponents
{
    public class CategoryViewComponent : ViewComponent
    {
        private readonly ICategory _categoryService;
        public CategoryViewComponent( ICategory category)
        {
            _categoryService = category;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var data = await _categoryService.GetAll();
            return View(data);
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RAShop.CustomerSite.Interfaces;
using RAShop.Shared.DTO;

namespace RAShop.CustomerSite.ViewComponents
{
    public class CategoryViewComponent : ViewComponent
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly ICategory _categoryService;
        public CategoryViewComponent(IHttpClientFactory clientFactory, ICategory category)
        {
            _clientFactory = clientFactory;
            _categoryService = category;
        }
        public IViewComponentResult Invoke()
        {
            var data = _categoryService.GetAll();
            return View(data);
        }
    }
}
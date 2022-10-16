using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RAShop.Backend.Models;
using RAShop.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.ComponentModel;

namespace RAShop.Backend.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly RAShopDbContext _context;
        public CategoryController(RAShopDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetAllCategory()
        {
            var categories = await _context.Categories.ToListAsync();
            return categories;
        }
        //[HttpGet("{id}")]
        //public Category GetCategoryById(int id)
        //{
        //    var category =  _context.Categories.FirstOrDefault(x => x.CategoryId == id);
        //    return category;
        //}
        //[HttpPost]
        //public Category CreateCategory(Category newCategory)
        //{
        //    _context.Categories.Add(newCategory);   
        //    _context.SaveChanges();
        //    return newCategory;
        //}
        //[HttpPut("{id}")]
        //public Category EditCategory(int id, Category newCategory)
        //{
        //    var category = _context.Categories.FirstOrDefault(x => x.CategoryId == id);
        //    if (category != null)
        //    {
        //        category = newCategory;
        //        _context.SaveChanges();
        //    }
        //    return category;
        //}
        //[HttpDelete("{id}")]
        //public Category DeleteCategory(int id)
        //{
        //    var category = _context.Categories.FirstOrDefault(x => x.CategoryId == id);
        //    if (category != null)
        //    {
        //        _context.Categories.Remove(category);
        //        _context.SaveChanges();
        //    }
        //    return category;
        //}
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RAShop.Backend.Models;
using RAShop.Backend.Data;
using RAShop.Shared.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.ComponentModel;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace RAShop.Backend.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly RAShopDbContext _context;
        private readonly IMapper _mapper;
        public CategoryController(RAShopDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //Lay tat ca loai san pham
        [HttpGet]
        public async Task<ActionResult<CategoryDTO>> GetAllCategory()
        {
            var categories = await _context.Categories.ToListAsync();
            CategoryDTO cateDto = _mapper.Map<CategoryDTO>(categories);
            return cateDto;
        }

        //Lay loai san pham theo id
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDTO>> GetCategoryById(int id)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(x => x.CategoryId == id);
            //return category;
            CategoryDTO cateDto = _mapper.Map<CategoryDTO>(category);
            return cateDto;
        }

        //Tao moi loai san pham
        [HttpPost]
        public async Task<ActionResult<Category>> CreateCate(Category newCate)
        {
            var cate = new Category()
            {
                CategoryId = newCate.CategoryId,
                CategoryName = newCate.CategoryName,
                Description = newCate.Description
            };
            await _context.Categories.AddAsync(cate);
            await _context.SaveChangesAsync();
            return cate;
        }

        //Sua mot category
        [HttpPut("{id}")]
        public async Task<ActionResult<Category>> EditCategory(int id, Category newCategory)
        {
            var category = _context.Categories.Find(id);
            if (category != null)
            {
                category.CategoryName = newCategory.CategoryName;
                category.Description = newCategory.Description;
            }
            await _context.SaveChangesAsync();
            return category;
        }

        //Xoa category
        [HttpDelete("{id}")]
        public async Task<ActionResult<Category>> DeleteCategory(int id)
        {
            var category = _context.Categories.FirstOrDefault(x => x.CategoryId == id);
            if (category != null)
            {
                 _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
            }
            return category;
        }
    }
}

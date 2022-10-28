using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RAShop.Backend.Data;
using RAShop.Backend.Models;
using RAShop.Shared.DTO;

namespace RAShop.Backend
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly RAShopDbContext _context;
        private readonly IMapper _mapper;
        public CategoryRepository(RAShopDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<CategoryDTO>> GetAllCategory()
        {
            var categories = await _context.Categories.Include(p => p.SubCates).ToListAsync();
            var listCateDTO = _mapper.Map<List<CategoryDTO>>(categories);
            return listCateDTO;
        }

        public async Task<CategoryDTO> GetCategoryById(int id)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(x => x.CategoryId == id);
            //return category;
            CategoryDTO cateDto = _mapper.Map<CategoryDTO>(category);
            return cateDto;
        }
        public async Task<Category> CreateCate(Category newCate)
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

        public async Task<Category> DeleteCategory(int id)
        {

            var category = _context.Categories.FirstOrDefault(x => x.CategoryId == id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
            }
            return category;
        }

        public async Task<Category> EditCategory(int id, Category newCategory)
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
    }
}
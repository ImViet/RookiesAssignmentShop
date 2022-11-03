using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RAShop.Backend.Data;
using RAShop.Backend.Extensions;
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
        //Lay danh muc cho admin
        public async Task<PagingDTO<CategoryDTO>> GetCategoryAdmin(string search, string sortOrder, int pageNumber, int pageSize)
        {
            //Query category
            var cateQuery = _context.Categories.AsQueryable();
            if (search != "")
            {
                cateQuery = cateQuery.Where(x => x.CategoryName.ToUpper().Contains(search.ToUpper()));
            }

            //Sort 
            cateQuery = SortCategory.Sorting(cateQuery, sortOrder);

            var countCate = await cateQuery.CountAsync();
            //Paging
            var categories = await cateQuery.Skip((pageNumber - 1) * pageSize)
                                    .Take(pageSize)
                                    .Include(x => x.SubCates)
                                    .ToListAsync();
            var listCateDTO = _mapper.Map<List<CategoryDTO>>(categories);
            var totalPages = (int)Math.Ceiling((double)countCate / pageSize);
            return new PagingDTO<CategoryDTO> { TotalPages = totalPages, items = listCateDTO };
        }

        public async Task<List<CategoryDTO>> GetAllCategory()
        {
            var categories = await _context.Categories.Include(s => s.SubCates).Include(p => p.Products).ToListAsync();
            var listCateDTO = _mapper.Map<List<CategoryDTO>>(categories);
            return listCateDTO;
        }

        public async Task<CategoryDTO> GetCategoryById(int id)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(x => x.CategoryId == id);
            CategoryDTO cateDto = _mapper.Map<CategoryDTO>(category);
            return cateDto;
        }
        public async Task<CategoryDTO> CreateCate(CreateCategoryDTO newCate)
        {
            var cate = _mapper.Map<Category>(newCate);
            await _context.Categories.AddAsync(cate);
            await _context.SaveChangesAsync();
            var result = _mapper.Map<CategoryDTO>(cate);
            return result;
        }

        public async Task<CategoryDTO> DeleteCategory(int id)
        {
            var category = _context.Categories.FirstOrDefault(x => x.CategoryId == id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
            }
            var result = _mapper.Map<CategoryDTO>(category);

            return result;
        }

        public async Task<CategoryDTO> EditCategory(EditCategoryDTO newCate)
        {
            var category = _context.Categories.FirstOrDefault(x => x.CategoryId == newCate.CateId);
            if (category != null)
            {
                _context.Categories.Update(category);
                _mapper.Map(newCate, category);
                await _context.SaveChangesAsync();
            }
            var result = _mapper.Map<CategoryDTO>(category);
            return result;
        }
    }
}
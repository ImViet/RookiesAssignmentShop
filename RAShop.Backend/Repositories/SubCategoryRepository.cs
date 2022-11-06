using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RAShop.Backend.Data;
using RAShop.Backend.Extensions;
using RAShop.Backend.Models;
using RAShop.Shared.DTO;

namespace RAShop.Backend
{
    public class SubCategoryRepository : ISubCategoryRepository
    {
        private readonly RAShopDbContext _context;
        private readonly IMapper _mapper;
        public SubCategoryRepository(RAShopDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<PagingDTO<SubCateDTO>> GetSubCategoryAdmin(string search, string sortOrder, int pageNumber, int pageSize)
        {
            //Query category
            var cateQuery = _context.SubCategories.AsQueryable();
            if (search != "")
            {
                cateQuery = cateQuery.Where(x => x.SubCategoryName.ToUpper().Contains(search.ToUpper()));
            }

            //Sort 
            cateQuery = SortCategory.SortingSubCate(cateQuery, sortOrder);

            var countCate = await cateQuery.CountAsync();
            //Paging
            var categories = await cateQuery.Skip((pageNumber - 1) * pageSize)
                                    .Include(c => c.Category)
                                    .Take(pageSize)
                                    .ToListAsync();
            var listCateDTO = _mapper.Map<List<SubCateDTO>>(categories);
            var totalPages = (int)Math.Ceiling((double)countCate / pageSize);
            return new PagingDTO<SubCateDTO> { TotalPages = totalPages, items = listCateDTO };
        }
        public async Task<List<SubCateDTO>> GetAllSubCategory()
        {
            var categories = await _context.SubCategories.Include(p => p.Products).Include(c => c.Category).ToListAsync();
            var listCateDTO = _mapper.Map<List<SubCateDTO>>(categories);
            return listCateDTO;
        }
        public async Task<List<SubCateDTO>> GetSubCategoryByCateId(int id)
        {
            var category = await _context.SubCategories.Where(x => x.CategoryId == id).ToListAsync();
            List<SubCateDTO> cateDto = _mapper.Map<List<SubCateDTO>>(category);
            return cateDto;
        }

        public async Task<SubCateDTO> GetSubCategoryById(int id)
        {
            var category = await _context.SubCategories.FirstOrDefaultAsync(x => x.SubCategoryId == id);
            SubCateDTO cateDto = _mapper.Map<SubCateDTO>(category);
            return cateDto;
        }
        public async Task<SubCateDTO> CreateSubCate(CreateSubCategoryDTO newCate)
        {
            var cate = _mapper.Map<SubCategory>(newCate);
            await _context.SubCategories.AddAsync(cate);
            await _context.SaveChangesAsync();
            var result = _mapper.Map<SubCateDTO>(cate);
            return result;
        }

        public async Task<SubCateDTO> DeleteSubCategory(int id)
        {
            var category = _context.SubCategories.FirstOrDefault(x => x.SubCategoryId == id);
            if (category != null)
            {
                _context.SubCategories.Remove(category);
                await _context.SaveChangesAsync();
            }
            var result = _mapper.Map<SubCateDTO>(category);
            return result;
        }

        public async Task<SubCateDTO> EditSubCategory(EditSubCategoryDTO newCate)
        {
            var category = _context.SubCategories.Include(c => c.Category).FirstOrDefault(x => x.SubCategoryId == newCate.SubCateId);
            if (category != null)
            {
                _context.SubCategories.Update(category);
                _mapper.Map(newCate, category);
                await _context.SaveChangesAsync();
            }
            var result = _mapper.Map<SubCateDTO>(category);
            return result;
        }


    }
}
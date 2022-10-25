using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RAShop.Backend.Data;
using RAShop.Backend.Models;
using RAShop.Shared.DTO;

namespace RAShop.Backend
{
    public class SubCategoryRepo : ISubCategory
    {
        private readonly RAShopDbContext _context;
        private readonly IMapper _mapper;
        public SubCategoryRepo(RAShopDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<SubCateDTO>> GetAllSubCategory()
        {
            var categories = await _context.SubCategories.ToListAsync();
            var listCateDTO = _mapper.Map<List<SubCateDTO>>(categories);
            return listCateDTO;
        }

        public async Task<SubCateDTO> GetSubCategoryById(int id)
        {
            var category = await _context.SubCategories.FirstOrDefaultAsync(x => x.SubCategoryId == id);
            //return category;
            SubCateDTO cateDto = _mapper.Map<SubCateDTO>(category);
            return cateDto;
        }
        public async Task<SubCategory> CreateSubCate(SubCategory newCate)
        {
            var cate = new SubCategory()
            {
                SubCategoryId = newCate.SubCategoryId,
                SubCategoryName = newCate.SubCategoryName,
                Description = newCate.Description
            };
            await _context.SubCategories.AddAsync(cate);
            await _context.SaveChangesAsync();
            return cate;
        }

        public async Task<SubCategory> DeleteSubCategory(int id)
        {
            var category = _context.SubCategories.FirstOrDefault(x => x.SubCategoryId == id);
            if (category != null)
            {
                _context.SubCategories.Remove(category);
                await _context.SaveChangesAsync();
            }
            return category;
        }

        public async Task<SubCategory> EditSubCategory(int id, SubCategory newCategory)
        {
            var category = _context.SubCategories.Find(id);
            if (category != null)
            {
                category.SubCategoryName = newCategory.SubCategoryName;
                category.Description = newCategory.Description;
            }
            await _context.SaveChangesAsync();
            return category;
        }


    }
}
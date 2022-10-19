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
    public class SubCateController : ControllerBase
    {
        private readonly RAShopDbContext _context;
        private readonly IMapper _mapper;
        public SubCateController(RAShopDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        //Lay tat ca loai san pham
        [HttpGet]
        public async Task<ActionResult<List<SubCateDTO>>> GetAllSubCategory()
        {
            var categories = await _context.SubCategories.ToListAsync();
            var listCateDTO = _mapper.Map<List<SubCateDTO>>(categories);
            return listCateDTO;
        }

        //Lay loai san pham theo id
        [HttpGet("{id}")]
        public async Task<ActionResult<SubCateDTO>> GetSubCategoryById(int id)
        {
            var category = await _context.SubCategories.FirstOrDefaultAsync(x => x.SubCategoryId == id);
            //return category;
            SubCateDTO cateDto = _mapper.Map<SubCateDTO>(category);
            return cateDto;
        }

        //Tao moi loai san pham
        [HttpPost]
        public async Task<ActionResult<SubCategory>> CreateSubCate(SubCategory newCate)
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

        //Sua mot category
        [HttpPut("{id}")]
        public async Task<ActionResult<SubCategory>> EditSubCategory(int id, SubCategory newCategory)
        {
            var category = _context.SubCategories.Find(id);
            if (category != null)
            {
                category.SubCategoryName = newCategory.SubCategoryName;
                category.Description = newCategory.Description;
            }
            await _context.SaveChangesAsync();
            return Ok();
        }

        //Xoa category
        [HttpDelete("{id}")]
        public async Task<ActionResult<SubCategory>> DeleteSubCategory(int id)
        {
            var category = _context.SubCategories.FirstOrDefault(x => x.SubCategoryId == id);
            if (category != null)
            {
                 _context.SubCategories.Remove(category);
                await _context.SaveChangesAsync();
            }
            return Ok();
        }
    }
}

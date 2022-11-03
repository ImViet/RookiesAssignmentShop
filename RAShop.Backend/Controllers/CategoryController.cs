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
        private readonly ICategoryRepository _categoryRepo;
        public CategoryController(ICategoryRepository categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        //Lay danh muc cho Admin
        [HttpPost]
        public async Task<ActionResult<PagingDTO<CategoryDTO>>> GetCategoryAdmin(
            [FromBody] CategoryAdminSearchDTO model)
        {
            return await _categoryRepo.GetCategoryAdmin(model.Query, model.SortOrder, model.Page, model.PageSize);
        }
        //Lay tat ca loai san pham
        [HttpGet]
        public async Task<ActionResult<List<CategoryDTO>>> GetAllCategory()
        {
            return await _categoryRepo.GetAllCategory();
        }

        //Lay loai san pham theo id
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDTO>> GetCategoryById(int id)
        {
            return await _categoryRepo.GetCategoryById(id);
        }

        //Tao moi loai san pham
        [HttpPost]
        public async Task<ActionResult<CategoryDTO>> CreateCate([FromBody] CreateCategoryDTO newCate)
        {
            return await _categoryRepo.CreateCate(newCate);
        }

        //Sua mot category
        [HttpPut]
        public async Task<ActionResult<CategoryDTO>> EditCategory([FromBody] EditCategoryDTO newCate)
        {
            return await _categoryRepo.EditCategory(newCate);
        }

        //Xoa category
        [HttpDelete("{id}")]
        public async Task<ActionResult<CategoryDTO>> DeleteCategory(int id)
        {
            return await _categoryRepo.DeleteCategory(id);
        }
    }
}

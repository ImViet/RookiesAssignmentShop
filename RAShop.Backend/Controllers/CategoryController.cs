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
        private readonly ICategoryRepo _categoryRepo;
        public CategoryController(ICategoryRepo categoryRepo)
        {
            _categoryRepo = categoryRepo;
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
        public async Task<ActionResult<Category>> CreateCate(Category newCate)
        {
            return await _categoryRepo.CreateCate(newCate);
        }

        //Sua mot category
        [HttpPut("{id}")]
        public async Task<ActionResult<Category>> EditCategory(int id, Category newCategory)
        {
            return await _categoryRepo.EditCategory(id, newCategory);
        }

        //Xoa category
        [HttpDelete("{id}")]
        public async Task<ActionResult<Category>> DeleteCategory(int id)
        {
            return await _categoryRepo.DeleteCategory(id);
        }
    }
}

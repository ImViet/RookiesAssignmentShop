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
        private readonly ISubCategoryRepository _subCategoryRepo;
        public SubCateController(ISubCategoryRepository subCategoryRepo)
        {
             _subCategoryRepo = subCategoryRepo;
        }
         //Lay danh muc cho Admin
        [HttpPost]
        public async Task<ActionResult<PagingDTO<SubCateDTO>>> GetSubCategoryAdmin(
            [FromBody] SubCategoryAdminSearchDTO model)
        {
            return await _subCategoryRepo.GetSubCategoryAdmin(model.Query, model.SortOrder, model.Page, model.PageSize);
        }
        //Lay tat ca loai san pham
        [HttpGet]
        public async Task<ActionResult<List<SubCateDTO>>> GetAllSubCategory()
        {
            return await _subCategoryRepo.GetAllSubCategory();
        }

        //Lay loai san pham theo id
        [HttpGet("{id}")]
        public async Task<ActionResult<SubCateDTO>> GetSubCategoryById(int id)
        {
            return await _subCategoryRepo.GetSubCategoryById(id);
            
        }

        //Tao moi loai san pham
        [HttpPost]
        public async Task<ActionResult<SubCateDTO>> CreateSubCate(CreateSubCategoryDTO newCate)
        {
            return await _subCategoryRepo.CreateSubCate(newCate);
         
        }

        //Sua mot category
        [HttpPut]
        public async Task<ActionResult<SubCateDTO>> EditSubCategory(EditSubCategoryDTO newCategory)
        {
            return await _subCategoryRepo.EditSubCategory(newCategory);
            
        }

        //Xoa category
        [HttpDelete("{id}")]
        public async Task<ActionResult<SubCateDTO>> DeleteSubCategory(int id)
        {
            return await _subCategoryRepo.DeleteSubCategory(id);
           
        }
    }
}

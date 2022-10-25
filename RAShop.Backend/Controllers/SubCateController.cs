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
        private readonly ISubCategory _subCategoryRepo;
        public SubCateController(ISubCategory subCategoryRepo)
        {
             _subCategoryRepo = subCategoryRepo;
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
        public async Task<ActionResult<SubCategory>> CreateSubCate(SubCategory newCate)
        {
            return await _subCategoryRepo.CreateSubCate(newCate);
         
        }

        //Sua mot category
        [HttpPut("{id}")]
        public async Task<ActionResult<SubCategory>> EditSubCategory(int id, SubCategory newCategory)
        {
            return await _subCategoryRepo.EditSubCategory(id, newCategory);
            
        }

        //Xoa category
        [HttpDelete("{id}")]
        public async Task<ActionResult<SubCategory>> DeleteSubCategory(int id)
        {
            return await _subCategoryRepo.DeleteSubCategory(id);
           
        }
    }
}

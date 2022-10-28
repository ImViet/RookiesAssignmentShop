using Microsoft.AspNetCore.Mvc;
using RAShop.Backend.Models;
using RAShop.Shared.DTO;

namespace RAShop.Backend
{
    public interface ISubCategoryRepository
    {
        Task<List<SubCateDTO>> GetAllSubCategory();
        Task<SubCateDTO> GetSubCategoryById(int id);
        Task<SubCategory> CreateSubCate(SubCategory newCate);
        Task<SubCategory> EditSubCategory(int id, SubCategory newCategory);
        Task<SubCategory> DeleteSubCategory(int id);

    }
}
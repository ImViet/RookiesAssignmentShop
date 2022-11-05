using Microsoft.AspNetCore.Mvc;
using RAShop.Backend.Models;
using RAShop.Shared.DTO;

namespace RAShop.Backend
{
    public interface ISubCategoryRepository
    {
        Task<PagingDTO<SubCateDTO>> GetSubCategoryAdmin(string search,  string sortOrder, int pageNumber, int pageSize);
        Task<List<SubCateDTO>> GetAllSubCategory();
        Task<SubCateDTO> GetSubCategoryById(int id);
        Task<SubCateDTO> CreateSubCate(CreateSubCategoryDTO newCate);
        Task<SubCateDTO> EditSubCategory(EditSubCategoryDTO newCategory);
        Task<SubCateDTO> DeleteSubCategory(int id);

    }
}
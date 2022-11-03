using Microsoft.AspNetCore.Mvc;
using RAShop.Backend.Models;
using RAShop.Shared.DTO;

namespace RAShop.Backend
{
    public interface ICategoryRepository
    {
        Task<PagingDTO<CategoryDTO>> GetCategoryAdmin(string search,  string sortOrder, int pageNumber, int pageSize);
        Task<List<CategoryDTO>> GetAllCategory();
        Task<CategoryDTO> GetCategoryById(int id);
        Task<CategoryDTO> CreateCate(CreateCategoryDTO newCate);
        Task<CategoryDTO> EditCategory(EditCategoryDTO newCate);
        Task<CategoryDTO> DeleteCategory(int id);

    }
}
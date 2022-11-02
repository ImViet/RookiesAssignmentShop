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
        Task<Category> CreateCate(Category newCate);
        Task<Category> EditCategory(int id, Category newCategory);
        Task<Category> DeleteCategory(int id);

    }
}
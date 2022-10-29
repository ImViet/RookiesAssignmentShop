using Microsoft.AspNetCore.Mvc;
using RAShop.Shared.DTO;

namespace RAShop.CustomerSite.Interfaces
{
    public interface ISubCategory 
    {
        Task<List<SubCateDTO>> GetAll();
    }
}

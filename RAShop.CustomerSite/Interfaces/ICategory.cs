using Microsoft.AspNetCore.Mvc;
using RAShop.Shared.DTO;

namespace RAShop.CustomerSite.Interfaces
{
    public interface ICategory 
    {
        public List<CategoryDTO> GetAll();
    }
}

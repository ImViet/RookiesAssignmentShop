using AutoMapper;
using RAShop.Backend.Models;
using RAShop.Shared.DTO;
namespace RAShop.Backend.Utilities.AutoMapper
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Category, CategoryDTO>();
        }
    }
}

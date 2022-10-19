using AutoMapper;
using RAShop.Backend.Models;
using RAShop.Shared.DTO;
namespace RAShop.Backend.Utilities.AutoMapper
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<SubCategory, SubCateDTO>();
            CreateMap<Category, CategoryDTO>()
                .ForMember(dest => dest.SubCates, cof=> cof.MapFrom(src => src.SubCates));
            CreateMap<Product, ProductDTO>()
                .ForMember(dest => dest.CategoryName, cof=> cof.MapFrom(src => src.SubCategory.SubCategoryName))
                .ForMember(dest => dest.MainImg, cof => cof.MapFrom(src => src.Image.MainImg));

        }
    }
}

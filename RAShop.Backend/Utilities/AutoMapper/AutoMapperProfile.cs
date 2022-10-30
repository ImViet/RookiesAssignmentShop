using AutoMapper;
using RAShop.Backend.Models;
using RAShop.Shared.DTO;
namespace RAShop.Backend.Utilities.AutoMapper
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<SubCategory, SubCateDTO>()
                .ForMember(dest => dest.Products, cof => cof.MapFrom(src => src.Products));

            CreateMap<Category, CategoryDTO>()
                .ForMember(dest => dest.SubCates, cof=> cof.MapFrom(src => src.SubCates))
                .ForMember(dest => dest.Products, cof => cof.MapFrom(src => src.Products));
            CreateMap<Product, ProductDTO>()
                .ForMember(dest => dest.CategoryName, cof=> cof.MapFrom(src => src.SubCategory.SubCategoryName))
                .ForMember(dest => dest.MainImg, cof => cof.MapFrom(src => src.MainImg))
                .ForMember(dest => dest.Ratings, cof => cof.MapFrom(src => src.Ratings));     
            CreateMap<Rating, RatingDTO>();
            CreateMap<AddRatingDTO, Rating>();

        }
    }
}

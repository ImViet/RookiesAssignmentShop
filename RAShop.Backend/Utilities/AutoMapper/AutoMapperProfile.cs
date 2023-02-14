using AutoMapper;
using RAShop.Backend.Models;
using RAShop.Shared.DTO;
using RAShop.Shared.DTO.Auth;

namespace RAShop.Backend.Utilities.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Product, ProductDTO>()
            .ForMember(dest => dest.CategoryId, cof => cof.MapFrom(src => src.CateId))
              .ForMember(dest => dest.CategoryName, cof => cof.MapFrom(src => src.Category.CategoryName))
              .ForMember(dest => dest.SubCategoryId, cof => cof.MapFrom(src => src.SubCateId))
              .ForMember(dest => dest.SubCategoryName, cof => cof.MapFrom(src => src.SubCategory.SubCategoryName))
              .ForMember(dest => dest.MainImg, cof => cof.MapFrom(src => src.MainImg))
              .ForMember(dest => dest.Ratings, cof => cof.MapFrom(src => src.Ratings));
            CreateMap<CreateProductDTO, Product>()
                .ForMember(dest => dest.CateId, cof => cof.MapFrom(src => src.CategoryId))
                .ForMember(dest => dest.SubCateId, cof => cof.MapFrom(src => src.SubCategoryId));
            CreateMap<EditProductDTO, Product>()
             .ForMember(dest => dest.CateId, cof => cof.MapFrom(src => src.CategoryId))
             .ForMember(dest => dest.SubCateId, cof => cof.MapFrom(src => src.SubCategoryId));
            CreateMap<Rating, RatingDTO>();
            CreateMap<AddRatingDTO, Rating>()
                .ForMember(dest => dest.ProductId, cof => cof.MapFrom(src => src.ProductId));
            CreateMap<Category, CategoryDTO>()
                .ForMember(dest => dest.SubCates, cof => cof.MapFrom(src => src.SubCates))
                .ForMember(dest => dest.Products, cof => cof.MapFrom(src => src.Products));
            CreateMap<CreateCategoryDTO, Category>()
                .ForMember(dest => dest.CategoryName, cof => cof.MapFrom(src => src.CateName));
            CreateMap<EditCategoryDTO, Category>()
                .ForMember(dest => dest.CategoryName, cof => cof.MapFrom(src => src.CateName));

            CreateMap<SubCategory, SubCateDTO>()
                .ForMember(dest => dest.CategoryParentId, cof => cof.MapFrom(src => src.Category.CategoryId))
                .ForMember(dest => dest.CategoryParentName, cof => cof.MapFrom(src => src.Category.CategoryName))
                .ForMember(dest => dest.Products, cof => cof.MapFrom(src => src.Products));
            CreateMap<CreateSubCategoryDTO, SubCategory>()
            .ForMember(dest => dest.CategoryId, cof => cof.MapFrom(src => src.CategoryId))
            .ForMember(dest => dest.SubCategoryName, cof => cof.MapFrom(src => src.SubCateName));
            CreateMap<EditSubCategoryDTO, SubCategory>()
                .ForMember(dest => dest.CategoryId, cof => cof.MapFrom(src => src.CategoryParentId))
                .ForMember(dest => dest.SubCategoryName, cof => cof.MapFrom(src => src.SubCateName));

            CreateMap<AppUser, AccountDTO>()
                .ForMember(dest => dest.Token, cof => cof.Ignore()); 
            CreateMap<RegisterRequestDTO, AppUser>();

        }
    }
}

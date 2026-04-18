using AutoMapper;
using NorthwindCatalog.Services.DTOs;
using NorthwindCatalog.Services.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace NorthwindCatalog.Services.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryDto>()
                .ForMember(dest => dest.ImageUrl,
                    opt => opt.MapFrom(src => "/images/" +
    src.CategoryName.Replace(" ", "")
                    .Replace("/", "")
    + ".jpeg"));

            CreateMap<Product, ProductDto>();
        }
    }

}
using AutoMapper;
using RoleBasedAuth.Api.Dtos.Products;
using RoleBasedAuth.Api.Models.Products;

namespace RoleBasedAuth.Api.Config
{
    public class ProductProfiles : Profile
    {

        public ProductProfiles()
        {
            CreateMap<Product, ProductDto>()
                .ReverseMap();

            CreateMap<ProductCategory, ProductCategoryDto>()
                .ReverseMap();  
                            
        }

    }
}

using AutoMapper;
using RoleBasedAuth.Api.Config;
using RoleBasedAuth.Api.Dtos.Products;
using RoleBasedAuth.Api.Models.Products;
using Xunit;

namespace RoleBasedAuth.Test.UnitTests.Products;

public class MapProducts
{

    private readonly IMapper _maper;

    public MapProducts()
    {
        var configuration = new MapperConfiguration( config =>
        {
            config.AddProfile<ProductProfiles>();
        });

        _maper = configuration.CreateMapper();
    }

    [Fact]
    public void CanMapProducts()
    {
        var baseCategories = new ProductCategory { Id = Guid.NewGuid(), Description = "Platos" };
        var product = new Product
        {
            Id = Guid.NewGuid(),
            Category = baseCategories,
            CategoryId = baseCategories.Id,
            Name = "Coca Cola 0 1.75L",
            Description = "Este producto es distibuido por la Coca-Cola Company",
            Price = 1200,
            PriceDiscount = 0,
            Quantity = 100
        };

        var productDto = _maper.Map<ProductDto>(product);

        var dto = new ProductDto
        {
           
            Name = "Product1", 
            Description = "deSC", 


        };

        var prod = _maper.Map<Product>(dto);

        Assert.NotNull(productDto);
        Assert.Equal(product.Name, productDto.Name);    
    }
}

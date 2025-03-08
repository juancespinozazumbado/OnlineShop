using Microsoft.EntityFrameworkCore;
using RoleBasedAuth.Api.Models.Products;

namespace RoleBasedAuth.Api.Dependencies;

public static class SeedProductsBase
{
    public static void SeedProducts(this ModelBuilder builder)
    {
 
        builder.Entity<Product>().HasData(SeedProducts());

    }


    private static IEnumerable<Product> SeedProducts()
    {
        var baseCategories = new List<ProductCategory>
        {
            new ProductCategory{  Id = Guid.NewGuid(), Description = "Refrescos"},
            new ProductCategory{  Id = Guid.NewGuid(), Description = "Birras"},
            new ProductCategory{  Id = Guid.NewGuid(), Description = "Copteles"},
            new ProductCategory{  Id = Guid.NewGuid(), Description = "Platos"}

        };


        return new List<Product> {
            new Product{Id = Guid.NewGuid(), Category = baseCategories[0], CategoryId = baseCategories[0].Id,
            Name = "Coca Cola 0 1.75L", Description= "Este producto es distibuido por la Coca-Cola Company",
            Price = 1200, PriceDiscount= 0, Quantity= 100
            },
            new Product{Id = Guid.NewGuid(), Category = baseCategories[0], CategoryId = baseCategories[0].Id,
            Name = "Coca Cola 0 2.5L", Description= "Este producto es distibuido por la Coca-Cola Company",
            Price = 1200, PriceDiscount= 0, Quantity= 100
            },
            new Product{Id = Guid.NewGuid(), Category = baseCategories[0], CategoryId = baseCategories[0].Id,
            Name = "Fanta Naranja 650 ML", Description=  "Este producto es distibuido por la Coca-Cola Company",
            Price = 1200, PriceDiscount= 0, Quantity= 100
            },
            new Product{Id = Guid.NewGuid(), Category = baseCategories[1], CategoryId = baseCategories[1].Id,
            Name = "Pilsen 6.0 0 de 600 ML", Description= "Este producto es distibuido por la Pilsen",
            Price = 1300, PriceDiscount= 0, Quantity= 100
            },
            new Product{Id = Guid.NewGuid(), Category = baseCategories[1], CategoryId = baseCategories[1].Id,
            Name = "Imperial Ligth 600 ML", Description= "Este producto es distibuido por Cerveseria",
            Price = 1200, PriceDiscount= 0, Quantity= 100
            }
        };
    }
}

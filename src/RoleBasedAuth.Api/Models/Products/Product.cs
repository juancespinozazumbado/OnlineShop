using System.Text.Json.Serialization;

namespace RoleBasedAuth.Api.Models.Products;

public class Product
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int Quantity { get; set; } = 0;
    public decimal Price { get; set; } = 0M;
    public decimal PriceDiscount { get; set; } = 0M;

    [JsonIgnore]
    public Guid? CategoryId { get; set; }
    [JsonIgnore]
    public ProductCategory? Category { get; set; }
}

public class ProductCategory
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }

    [JsonIgnore]
    public List<Product>? Products { get; set;}

}

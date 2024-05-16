﻿using RoleBasedAuth.Api.Models.Products;

namespace RoleBasedAuth.Api.DTOS;

public class ProductDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int Quantity { get; set; } = 0;
    public decimal Price { get; set; } = 0M;
    public decimal PriceDiscount { get; set; } = 0M;

    public string? CategoryId { get; set; }
    public ProductCategory? Category { get; set; }
}

using Microsoft.EntityFrameworkCore;
using RoleBasedAuth.Api.Models.Orders;
using RoleBasedAuth.Api.Models.Products;

namespace RoleBasedAuth.Api.Dependencies;

public static class ProductsDataConfig
{
    public static void SetUpDomainContext(this ModelBuilder builder)
    {
        builder.Entity<Product>()
       .HasOne(p => p.Category)
       .WithMany(c => c.Products).HasForeignKey(P => P.CategoryId)
       .HasPrincipalKey(p => p.Id);

        builder.Entity<Order>()
            .HasMany(o => o.Details)
            .WithOne(od => od.Order)
            .HasForeignKey(o => o.OrderId)
            .HasPrincipalKey(od => od.Id);

        builder.Entity<Order>()
            .HasOne(o => o.Customer)
            .WithMany(c => c.Orders)
            .HasForeignKey(o => o.CustomerId);

        builder.Entity<Customer>()
            .HasMany(c => c.Orders)
            .WithOne(o => o.Customer)
            .HasForeignKey(o => o.CustomerId);


        builder.Entity<OrderDetail>()
            .HasOne(d => d.Product);
    }
}

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RoleBasedAuth.Api.Models.Auth;
using RoleBasedAuth.Api.Models.Orders;
using RoleBasedAuth.Api.Models.Products;

namespace RoleBasedAuth.Api.contexts;

public class RoleBaedDbContext : IdentityDbContext<User>
{
    // Required for EF Coe
    public RoleBaedDbContext(DbContextOptions<RoleBaedDbContext> options) : base(options)
    {

    }

    //Here we define all our DbSets of the models

    public DbSet<Product> Products {get; set;}
    public DbSet<ProductCategory> ProductCategories { get; set;}

    //Orders

    public DbSet<Order> Oreders { get; set;}   
    //public DbSet<OrderDetail> OrderDetails { get; set;}

    public DbSet<Customer> Customers { get; set;}


    // Configure all the models and constrigs as you need
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Product>()
            .HasOne(p => p.Category)
            .WithMany(c=> c.Products).HasForeignKey(P => P.CategoryId)
            .HasPrincipalKey( p => p.Id);

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

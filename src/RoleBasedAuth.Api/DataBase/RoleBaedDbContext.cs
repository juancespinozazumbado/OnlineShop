using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RoleBasedAuth.Api.Dependencies;
using RoleBasedAuth.Api.Models.Auth;
using RoleBasedAuth.Api.Models.Orders;
using RoleBasedAuth.Api.Models.Products;
using System.Reflection;

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

        builder.ConfigureAuthbasic();
        

        builder.SetUpDomainContext();

        builder.SeedProducts();

        //builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());




    }
}

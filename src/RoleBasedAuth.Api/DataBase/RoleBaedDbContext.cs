using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RoleBasedAuth.Api.Models.Auth;
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


    // Configure all the models and constrigs as you need
    protected override void OnModelCreating(ModelBuilder builder)
    {


        base.OnModelCreating(builder);

        builder.Entity<Product>()
            .HasOne(p => p.Category)
            .WithMany(c=> c.Products).HasForeignKey(P => P.CategoryId)
            .HasPrincipalKey( p => p.Id);
    }
}

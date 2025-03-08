using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RoleBasedAuth.Api.Models.Auth;

namespace RoleBasedAuth.Api.Dependencies;

public static class AuthDataConfig
{
    public static void ConfigureAuthbasic(this ModelBuilder modelBuilder)
    {
        var adminRole = new IdentityRole { Id = "10001", Name = "Admin", NormalizedName = "ADMIN" };
        modelBuilder.Entity<IdentityRole>()
            .HasData(
            adminRole,
            new IdentityRole { Id = "10002", Name = "User", NormalizedName = "USER" }

            );
        var adminUser = new User
        {
            Id= Guid.NewGuid().ToString(),
            UserName = "admin", 
            NormalizedUserName = "admin".ToUpper(),
            Email = "admin@shop.com", 
            NormalizedEmail = "admin@shop.com".ToUpper(), 
            EmailConfirmed = true
        };

        var passworHasher = new PasswordHasher<User>();
        adminUser.PasswordHash = passworHasher.HashPassword(adminUser, "admin@22");

        modelBuilder.Entity<User>().HasData(adminUser );

        modelBuilder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string> { UserId = adminUser.Id, RoleId = adminRole.Id }
            );

    }


}

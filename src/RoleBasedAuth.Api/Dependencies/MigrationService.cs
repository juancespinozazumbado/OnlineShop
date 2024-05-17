using Microsoft.EntityFrameworkCore;
using RoleBasedAuth.Api.contexts;

namespace RoleBasedAuth.Api.Dependencies;

public static class MigrationService
{
    public static async void DataBaseMigrationInitialization(IApplicationBuilder app)
    {
        using(var serviceScope = app.ApplicationServices.CreateScope())
        {
            var dbCOntext = serviceScope.ServiceProvider.GetRequiredService<RoleBaedDbContext>();
            await dbCOntext.Database.MigrateAsync();

            
        }
    }
}

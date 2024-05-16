using RoleBasedAuth.Api.DataBase;
using RoleBasedAuth.Api.Interfaces;

namespace RoleBasedAuth.Api.Dependencies;

public static class MainDependencies
{
    public static IServiceCollection AddRepository(this IServiceCollection services)
    {
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        return services;
    }
}

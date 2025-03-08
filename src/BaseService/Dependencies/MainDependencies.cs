using RoleBasedAuth.Api.DataBase;
using RoleBasedAuth.Api.Interfaces;
using RoleBasedAuth.Api.Services;

namespace RoleBasedAuth.Api.Dependencies;

public static class MainDependencies
{
    public static IServiceCollection AddRepository(this IServiceCollection services)
    {
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        return services;
    }

    public static IServiceCollection AddAutneticatorServices(this IServiceCollection services)
    {

        services.AddScoped<ITokenProvider, TokenProvider>();
        services.AddScoped<IAuthenticatorService, AuthenticationService>();
        

        return services;
    }
}

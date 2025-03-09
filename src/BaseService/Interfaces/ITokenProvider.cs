using RoleBasedAuth.Api.Models.Auth;

namespace RoleBasedAuth.Api.Interfaces;

public interface ITokenProvider
{

    public Task<string> WriteToken(User user);
}


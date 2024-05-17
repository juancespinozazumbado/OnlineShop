using RoleBasedAuth.Api.Models.Auth;

namespace RoleBasedAuth.Api.Interfaces;

public interface ITokenProvider
{
   
    string WriteToken(User user);
}


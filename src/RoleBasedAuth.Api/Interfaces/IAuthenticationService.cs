using RoleBasedAuth.Api.Dtos.Auth;

namespace RoleBasedAuth.Api.Interfaces;

public interface IAuthenticatorService
{
    Task<dynamic> Register(RegisterRequest registroRequest);

    Task<dynamic> Login(LoginRequest loginRequest);

   // Task<dynamic> CambiarContraseña(CambioDeContraseñaRequestDto request);
}

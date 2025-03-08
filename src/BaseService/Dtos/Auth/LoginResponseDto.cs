namespace RoleBasedAuth.Api.Dtos.Auth;

public record LoginResponseDto
{
    public UserDto? User { get; set; }
    public string? Token { get; set; } = string.Empty;  
}

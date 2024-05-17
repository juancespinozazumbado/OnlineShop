using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using RoleBasedAuth.Api.Config;
using RoleBasedAuth.Api.Interfaces;
using RoleBasedAuth.Api.Models.Auth;
using System.IdentityModel.Tokens.Jwt;
using System.Numerics;
using System.Security.Claims;
using System.Text;

namespace RoleBasedAuth.Api.Services;

public class TokenProvider : ITokenProvider
{

    private readonly UserManager<User> _userManager;
    private readonly JWTOptions _jwtOptions;
    private readonly RoleManager<IdentityRole> _roleManager;


    public TokenProvider(UserManager<User> userManager, IOptions<JWTOptions> jWTOptions, 
        RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        this._jwtOptions = jWTOptions.Value;
        _roleManager = roleManager;
    }   

    public async Task<string> WriteToken(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_jwtOptions.Secret);

        var claimList = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Email,user.Email),
            new Claim(JwtRegisteredClaimNames.Sub,user.Id),
            new Claim(JwtRegisteredClaimNames.Name,user.UserName)
        };

        var userRoles = await _userManager.GetRolesAsync(user);
        claimList.AddRange(userRoles.Select(role => new Claim(ClaimTypes.Role, role)));

        var tokenDescriptor = new SecurityTokenDescriptor
        {

            Audience = _jwtOptions.Audience,
            Issuer = _jwtOptions.Issuer,
            Subject = new ClaimsIdentity(claimList),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
            SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
        
    }
}

using Azure.Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.Identity.Client;
using RoleBasedAuth.Api.Dtos.Auth;
using RoleBasedAuth.Api.Interfaces;
using RoleBasedAuth.Api.Models.Auth;

namespace RoleBasedAuth.Api.Services;

public class AuthenticationService : IAuthenticatorService
{

    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;    
    private readonly ITokenProvider _tokenProvider;

    public AuthenticationService(UserManager<User> userManager,
        SignInManager<User> signInManager, ITokenProvider tokenProvider)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _tokenProvider = tokenProvider;

    }

    public async Task<dynamic> Login(LoginRequest loginRequest)
    {
        var user = await _userManager.FindByEmailAsync(loginRequest.Email);

        if (user is not null)
        {
            var result = await _signInManager.CheckPasswordSignInAsync(user, loginRequest.Password, false);

            if (result.Succeeded)
            {
                return new
                {
                    UserDetails = new
                    {
                        UserName = user.UserName,
                        Email = user.Email,
                    },
                    Token = _tokenProvider.WriteToken(user)

                };

            }
            else return new
            {
                Mesage = "Login atemp faild!"
            };
        }
        else return new
        {
            Error = "User not found!"
        };



    }

    public async Task<dynamic> Register(RegisterRequest registroRequest)
    {

        var user = new User
        {
            UserName = registroRequest.Name,
            Email = registroRequest.Email,

        };

        var reuslt = await _userManager.CreateAsync(user, registroRequest.Password);

        if (reuslt.Succeeded)
        {
            return new
            {
                Usernam = user.UserName,
                Email = user.Email,
                Message = "User careated!"
            };
        }
        else return new
        {
            Meassage = "User Cant register!"
        };
    }

}

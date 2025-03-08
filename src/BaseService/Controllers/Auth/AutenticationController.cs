using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RoleBasedAuth.Api.Dtos.Auth;
using RoleBasedAuth.Api.Interfaces;
using RoleBasedAuth.Api.Models.Auth;

namespace RoleBasedAuth.Api.Controllers.Auth;

[ApiController]
[Route("[controller]")]
public class AutenticationController : ControllerBase
{
    private readonly UserManager<User> _userManager;  
    private readonly IAuthenticatorService _authService;

    public AutenticationController(UserManager<User> userManager,
        IAuthenticatorService authService)
    {
        _userManager = userManager;
        _authService = authService;
    }

    [HttpPost("login")]
    public async Task<ActionResult<dynamic>> Login(LoginRequest loginRequest)
    {

     
        var result = await _authService.Login(loginRequest);

        return Ok(result);

    }

    [HttpPost("register")]
    public async Task<ActionResult<dynamic>> Register(RegisterRequest request)
    {


        var result = await _authService.Register(request);

        return Ok(result);

    }


}

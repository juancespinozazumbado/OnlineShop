using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace RoleBasedAuth.Api.Controllers.Auth;

public class RoleAuthFilter : AuthorizeAttribute, IAuthorizationFilter
{

    private readonly string  _role;

    public RoleAuthFilter(string role)
    {
        _role = role;
    }



    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var user = context.HttpContext.User;
        if (!user.Identity.IsAuthenticated)
        {
            context.Result = new UnauthorizedResult();
            return;
            
        }

        var roles = user.Claims.Where( c=> c.Type == System.Security.Claims.ClaimTypes.Role).Select( c => c.Value ).ToList();   
        if(!roles.Contains(_role))
        {
            context.Result = new UnauthorizedResult();  
        }

       
    }
}

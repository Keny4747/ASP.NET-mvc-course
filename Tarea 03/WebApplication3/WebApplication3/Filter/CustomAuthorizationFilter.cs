using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using System.Security.Claims;

namespace WebApplication3.Filter
{
    public class CustomAuthorizationFilter : IAuthorizationFilter
    {
        private readonly string[] _allowedRoles;
        public CustomAuthorizationFilter(string[] allowedRoles)
        {
            _allowedRoles = allowedRoles;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            // Verifica si el usuario está autenticado
            if (!context.HttpContext.User.Identity.IsAuthenticated)
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            // Verifica si el usuario tiene uno de los roles permitidos
            var userRoles = context.HttpContext.User.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value);
            if (!_allowedRoles.Any(userRoles.Contains))
            {
                context.Result = new ForbidResult();
                return;
            }
        }
    }
}

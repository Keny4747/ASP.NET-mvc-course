using WebApplication3.Models;

namespace WebApplication3.Security
{
    public interface ICustomAuthenticationService
    {
        bool SignIn(HttpContext httpContext, string usuario, string password, bool isPersistent = false);
        void SignOut(HttpContext httpContext);
    }
}

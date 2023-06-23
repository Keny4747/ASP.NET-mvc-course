using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using WebApplication3.Repository;
using WebApplication3.Models;
using WebApplication3.Utils;

namespace WebApplication3.Security
{
    public class CustomAuthenticationService: ICustomAuthenticationService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IRolRepository _rolRepository;

        public CustomAuthenticationService(IUsuarioRepository usuarioRepository, IRolRepository rolRepository)
        {
            _usuarioRepository = usuarioRepository;
            _rolRepository = rolRepository;
        }

        public bool SignIn(HttpContext httpContext, string usuario, string password, bool isPersistent = false)
        {
            var user = _usuarioRepository.ObtenerPorNombreUsuario(usuario);
            if (user != null)
            {
                if (user.contrasenia != Utilitarios.GetMd5Hash(password))
                {
                    return false;
                }
                var roles = new List<RolModel>();
                foreach(var ur in user.usuarioRoles)
                {
                    roles.Add(_rolRepository.ObtenerPorID(ur.rol_id));
                }
                ClaimsIdentity identity = new ClaimsIdentity(this.GetUserClaims(user, roles), CookieAuthenticationDefaults.AuthenticationScheme);
                ClaimsPrincipal principal = new ClaimsPrincipal(identity);

                httpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                return true;

            }
            return false;
        }

        public async void SignOut(HttpContext httpContext)
        {
            await httpContext.SignOutAsync();
        }

        private IEnumerable<Claim> GetUserClaims(UsuarioModel user, List<RolModel> roles)
        {
            List<Claim> claims = new List<Claim>();

            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.id.ToString()));
            claims.Add(new Claim(ClaimTypes.Name, user.usuario));
            //claims.Add(new Claim(ClaimTypes.Email, user.UserEmail));
            claims.AddRange(this.GetUserRoleClaims(user, roles));
            return claims;
        }

        private IEnumerable<Claim> GetUserRoleClaims(UsuarioModel user, List<RolModel> roles)
        {
            List<Claim> claims = new List<Claim>();
            
            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.id.ToString()));
            foreach (var rol in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, rol.nombre));
            }
            return claims;
        }
    }
}

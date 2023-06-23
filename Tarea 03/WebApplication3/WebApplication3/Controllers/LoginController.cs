using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;
using WebApplication3.Repository;
using WebApplication3.Security;
using WebApplication3.Service;
using WebApplication3.Utils;

namespace WebApplication3.Controllers
{
    public class LoginController : Controller
    {
        private readonly ICustomAuthenticationService _customAuthenticationService;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IRolRepository _rolRepository;
        private readonly IUsuarioService _usuarioService;
        public LoginController(ICustomAuthenticationService customAuthenticationService, IUsuarioRepository usuarioRepository, IRolRepository rolRepository, IUsuarioService usuarioService)
        {
            this._customAuthenticationService = customAuthenticationService;
            this._usuarioRepository = usuarioRepository;
            this._rolRepository = rolRepository;
            this._usuarioService = usuarioService;
        }

        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Venta");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login([Bind("usuario,contrasenia")] UsuarioModel user)
        {
            if (ModelState.IsValid)
            {
                string _usuario = user.usuario;
                string _password = user.contrasenia;
                var statusLogin = _customAuthenticationService.SignIn(this.HttpContext, _usuario, _password);
                if (statusLogin)
                {
                    return RedirectToAction("Index", "Venta"); 
                } else
                {
                    return RedirectToAction("Index", "Login");
                }
            } else
            {
                return View("Index");
            }
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register([Bind("usuario,contrasenia")] UsuarioModel user)
        {
            if (ModelState.IsValid)
            {
                var rol = _rolRepository.ObtenerPorID(2);
                var roles = new List<RolModel>();
                roles.Add(rol);
                user.contrasenia = Utilitarios.GetMd5Hash(user.contrasenia);
                var status = _usuarioService.RegistrarUsuario(user, roles);
                if (!status)
                {
                    return View(user);
                }
                return RedirectToAction("Index");
            } else
            {
                return View(user);
            }
        }
        [Authorize]
        public IActionResult Logout()
        {
            _customAuthenticationService.SignOut(this.HttpContext);
            return View("Index");
        }
    }
}

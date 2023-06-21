using Microsoft.AspNetCore.Mvc;
using Pregunta02.Models;

namespace Pregunta02.Controllers
{
    public class UsuarioController : Controller
    {

        public IActionResult Index()
        {
            ViewBag.Temas = new List<string> { "Musica", "Deporte", "Teatro", "Ciencias" };
            return View();
        }

        [HttpPost]
        public IActionResult Registrar(UsuarioModel usuario)
        {

            Response.Cookies.Append("tema", usuario.nombre);
            return RedirectToAction("Index", "Usuario");
        }
    }
}

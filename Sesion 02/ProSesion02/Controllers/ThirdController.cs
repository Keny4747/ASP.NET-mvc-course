using Microsoft.AspNetCore.Mvc;

namespace ProSesion02.Controllers
{
    public class ThirdController : Controller
    {
        public IActionResult Index()
        {
            var mensaje = " ";
            if (TempData.ContainsKey("mensaje")) {
                mensaje = TempData["mensaje"].ToString();
            }
            else
            {
                mensaje = "No hay mensaje disponible";
            }

            ViewData["mensaje"] = mensaje; 
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using ProSesion02.Models;
using System.Diagnostics;

namespace ProSesion02.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //ViewData
            var estudiantes = new List<Estudiante>
            {
                new Estudiante {nombre = "Carlos", apellido="Gonzales",edad=22 },
                new Estudiante {nombre = "Pedro", apellido="Paredes",edad=22 },
                new Estudiante {nombre = "Alexandra", apellido="Ramirez",edad=22 },
                new Estudiante {nombre = "Maria", apellido="Perez",edad=22 },
            };

            ViewData["estudiantes"] = estudiantes;
            ViewData["titulo"] = "Lista de estudiantes";
            ViewData["total"] = estudiantes.Count;

            HttpContext.Session.SetString("Usuario", "Javier");
            HttpContext.Session.SetString("Email", "javie@gmail.com");


            return View();
        }

        public IActionResult Privacy()
        {
            //ViewBag
            var estudiantes = new List<Estudiante>
            {
                new Estudiante {nombre = "Carlos", apellido="Gonzales",edad=22 },
                new Estudiante {nombre = "Pedro", apellido="Paredes",edad=22 },
                new Estudiante {nombre = "Alexandra", apellido="Ramirez",edad=22 },
                new Estudiante {nombre = "Maria", apellido="Perez",edad=22 },
            };

            ViewBag.estudiantes = estudiantes;
            ViewBag.titulo = "Lista de estudiantes";
            ViewBag.total = estudiantes.Count;

       
            return View();
        }


        //Cookies
        public ActionResult Cookies()
        {
            HttpContext.Response.Cookies.Append("user_id", "123");
            HttpContext.Response.Cookies.Append("user_token", "SDFF2NF25º1");
            return View();
        }

        //Sessions
        public IActionResult SessionPage() { 
                
            ViewBag.usuario = HttpContext.Session.GetString("Usuario");
            ViewBag.email = HttpContext.Session.GetString("Email");

            return View("Session"); 
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
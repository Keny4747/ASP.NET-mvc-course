using Microsoft.AspNetCore.Mvc;

namespace ProSesion02.Controllers
{
    public class SecondController : Controller
    {
        public IActionResult Index()
        {
            //rediriendo al metodo index del ThirdController, además de enviar un mensaje
            TempData["mensaje"] = "mensaje enviado del segundo controller."; 
            return RedirectToAction("Index","Third");
        }


    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tarea02.Models;

namespace Tarea02.Controllers
{
    public class LibroController : Controller
    {
        protected IConfiguration configuration;

        public LibroController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        //MOSTRAR LIBROS:
        public IActionResult Index()
        {
            LibroModel model = new LibroModel();


            using (var contextDB = new ApplicationContext(configuration))
            {
                var ventas = contextDB.librosCollection.ToList();
                return View(ventas);
            }

        }
        //MOSTRAR LIBRO:
        public IActionResult Detalle(int id)
        {
            using (var _contextDB = new ApplicationContext(configuration))
            {
                var libro = _contextDB.librosCollection.Find(id);
                if (libro != null)
                {
                    return View(libro);
                }
            }

            return RedirectToAction("Index");
        }


        //CREAR LIBROS:
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(LibroModel venta)
        {
   
            if (ModelState.IsValid)
            {
                using (var _contextDB = new ApplicationContext(configuration))
                {
                    //Se agrega el libro  a la BD
                    _contextDB.librosCollection.Add(venta);
                    _contextDB.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            else
            {
               
                return View(venta);
            }
        }
        //ACTUALIZAR LIBRO:
        public IActionResult Actualizar(int id)
        {
            var libro = new LibroModel(); ;
            using (var contextDB = new ApplicationContext(configuration))
            {

                libro = contextDB.librosCollection.Find(id);
            }

            return View(libro);
        }

        [HttpPost]
        public IActionResult Actualizar(LibroModel libro)
        {
           
            if (ModelState.IsValid)
            {
                using (var _contextDB = new ApplicationContext(configuration))
                {
                    //Se agrega el libro a la BD
                    _contextDB.Entry(libro).State = EntityState.Modified;
                    _contextDB.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            else
            {
                
                return View(libro);
            }
        }

        //Eliminar libro:
        [HttpPost]
        public IActionResult Delete(int id)
        {
            using (var _contextDB = new ApplicationContext(configuration))
            {
                var libro = _contextDB.librosCollection.Find(id);
                if (libro != null)
                {
                    _contextDB.librosCollection.Remove(libro);
                    _contextDB.SaveChanges();
                }
                
                
            }
            return RedirectToAction("Index");
        }
    }
}

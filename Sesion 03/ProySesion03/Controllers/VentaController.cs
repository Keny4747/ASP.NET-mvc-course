using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProySesion03.Models;

namespace ProySesion03.Controllers
{
    public class VentaController : Controller
    {
        protected IConfiguration configuration;

        public VentaController (IConfiguration configuration)
        {
            this.configuration = configuration; 
        }
        public IActionResult Index()
        {
            VentaModel model = new VentaModel();
           

            using (var contextDB = new ApplicationContext(configuration))
            {
                var ventas = contextDB.ventasCollection.ToList ();
                return View(ventas);
            }
                
        }
        //////////////////////////////////////////////////////////////////
        //CREAR VENTA
        /////////////////////////////////////////////////////////////////
        //Este solo entrega la vista inicial del formulario de nueva venta
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(VentaModel venta)
        {
            //Se valida que las propiedades del modelo sean correctar y validas
            if(ModelState.IsValid) { 
                using(var _contextDB = new ApplicationContext(configuration))
                {
                    //Se agraga la venta a la BD
                    _contextDB.ventasCollection.Add (venta);
                    _contextDB.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            else
            {
                //se le manda con los valores cargados en los inputs de la vista de tal forma que no se pierden y continuar para hacer el POST
                return View(venta);
            }
        }
        //////////////////////////////////////////////////////////////////
        //ACTUALIZAR VENTA
        /////////////////////////////////////////////////////////////////
        public IActionResult Actualizar(int id)
        {
            var venta = new VentaModel(); ;
            using(var contextDB = new ApplicationContext(configuration)) { 
                
                venta = contextDB.ventasCollection.Find (id);
            }

            return View(venta);
        }
        [HttpPost]
        public IActionResult Actualizar(VentaModel venta)
        {
            //Se valida que las propiedades del modelo sean correctar y validas
            if (ModelState.IsValid)
            {
                using (var _contextDB = new ApplicationContext(configuration))
                {
                    //Se agraga la venta a la BD
                    _contextDB.Entry(venta).State = EntityState.Modified;
                    _contextDB.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            else
            {
                //se le manda con los valores cargados en los inputs de la vista de tal forma que no se pierden y continuar para hacer el POST
                return View(venta);
            }
        }

    }
}

using Microsoft.AspNetCore.Mvc;
using Proy_I.Models;

namespace Proy_I.Controllers
{
    public class HelpController : Controller
    {
        public IConfiguration configuration;
        public HelpController(IConfiguration configuration) {
            this.configuration = configuration;
        }
        public IActionResult Index()
        {
            //variable para la conexión a base de datos
            var universidadContext = new UniversidadContext(configuration);
            universidadContext.Database.EnsureCreated();

            //objeto para registrar
            var docente = new DocenteModel();
            docente.nombre = "Keny";
            docente.apellido = "Pauccarima";

            //INSERT INTO docente (nombre, apellido)...
            universidadContext.docenteModel.Add(docente);
            //commit
            universidadContext.SaveChanges();

            /*

            //SELECT * FROM docente WHERE id = 5;
            var estudiante2 = universidadContext.docenteModel.Find(5);

            //UPDATE
            var estudiante3 = universidadContext.docenteModel.Find(5);
            estudiante3.nombre = "Keny J.";
            universidadContext.docenteModel.Update(estudiante3);
            universidadContext.SaveChanges();

            //DELETE
            var estudiante4 = universidadContext.docenteModel.Find(8);
            universidadContext.docenteModel.Remove(estudiante4);
            universidadContext.SaveChanges();
            */
            return View();
        }
    }
}

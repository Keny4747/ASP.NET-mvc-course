using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationAPI.Models;
using WebApplicationAPI.Repository;
using WebApplicationAPI.Service;
using WebApplicationAPI.Utils;
using WebApplicationAPI.ViewModels;

namespace WebApplicationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase
    {

        private readonly ILibroRepository libroRepository;
        private readonly ILibroService libroService;

        public LibroController(ILibroRepository libroRepository, ILibroService libroService)
        {
            this.libroRepository = libroRepository;
            this.libroService = libroService;
        }


        [HttpGet]
        public async Task<ActionResult<LibroViewModel>> GetLibrosCollection(int pageNumber = 1, int pageSize = 3)
        {

            return libroRepository.ObtenerTodosPagination(pageNumber, pageSize);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<LibroModel>> GetUsuarioModel(int id)
        {
            return libroRepository.ObtenerPorID(id);
        }

    
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLibroModel(int id, LibroModel libroModel)
        {
            if (id != libroModel.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    libroRepository.Actualizar(libroModel);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LibroModelExists(libroModel.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return NoContent();
            }
            return NoContent();
        }

      
  
        [HttpPost]
        public async Task<ActionResult<LibroModel>> PostUsuarioModel(LibroModel libroModel)
        {
            if (ModelState.IsValid)
            {
              
                
                libroService.RegistrarLibro(libroModel);
                return NoContent();
            }

            return NoContent();
        }

      
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLibroModel(int id)
        {
            var libroModel = libroRepository.ObtenerPorID(id);

            return NoContent();
        }

        private bool LibroModelExists(int id)
        {
            return libroRepository.ObtenerPorID(id) != null;
        }
    }
}

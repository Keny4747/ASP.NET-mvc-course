using WebApplicationAPI.Models;

namespace WebApplicationAPI.Service
{
    public interface ILibroService
    {
        bool RegistrarLibro(LibroModel libro);
    }
}

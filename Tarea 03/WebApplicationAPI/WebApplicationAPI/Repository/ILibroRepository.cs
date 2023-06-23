using WebApplicationAPI.Models;
using WebApplicationAPI.ViewModels;

namespace WebApplicationAPI.Repository
{
    public interface ILibroRepository
    {

        LibroModel ObtenerPorID(int id);
        LibroModel ObtenerPorNombre(string nombre_usuario);
        List<LibroModel> ObtenerTodos();
        LibroViewModel ObtenerTodosPagination(int pageNumber, int pageSize);
        void Crear(LibroModel model);
        void Actualizar(LibroModel model);
        void Eliminar(int id);
    }
}

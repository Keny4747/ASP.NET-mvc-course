using WebApplication3.Models;

namespace WebApplication3.Repository
{
    public interface IRolRepository
    {
        RolModel ObtenerPorID(int id);
        List<RolModel> ObtenerTodos();
        void Crear(RolModel model);
        void Actualizar(RolModel model);
        void Eliminar(int id);
    }
}

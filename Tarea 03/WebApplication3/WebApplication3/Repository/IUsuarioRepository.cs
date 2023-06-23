using WebApplication3.Models;

namespace WebApplication3.Repository
{
    public interface IUsuarioRepository
    {
        UsuarioModel ObtenerPorID(int id);
        UsuarioModel ObtenerPorNombreUsuario(string nombre_usuario);
        List<UsuarioModel> ObtenerTodos();
        void Crear(UsuarioModel model);
        void Actualizar(UsuarioModel model);
        void Eliminar(int id);
    }
}

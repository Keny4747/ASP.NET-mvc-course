using WebApplication3.Models;

namespace WebApplication3.Service
{
    public interface IUsuarioService
    {
        bool RegistrarUsuario(UsuarioModel model, List<RolModel> roles);
    }
}

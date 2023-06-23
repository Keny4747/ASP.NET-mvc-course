using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;

namespace WebApplication3.Repository
{
    public class UsuarioRolRepository: IUsuarioRolRepository
    {
        private readonly ApplicationDBContext applicationDBContext;
        public UsuarioRolRepository(ApplicationDBContext applicationDBContext)
        {
            this.applicationDBContext = applicationDBContext;
        }

        public void Actualizar(UsuarioRolModel model)
        {
            applicationDBContext.Entry(model).State = EntityState.Modified;
            applicationDBContext.SaveChanges();
        }

        public void Crear(UsuarioRolModel model)
        {
            applicationDBContext.usuarioRolsCollection.Add(model);
            applicationDBContext.SaveChanges();
        }

        public void Eliminar(int id)
        {
            var model = applicationDBContext.usuarioRolsCollection.Find(id);
            if (model != null)
            {
                applicationDBContext.usuarioRolsCollection.Remove(model);
            }
            applicationDBContext.SaveChangesAsync();
        }

        public UsuarioRolModel ObtenerPorID(int id)
        {
            return applicationDBContext.usuarioRolsCollection.Find(id);
        }

        public List<UsuarioRolModel> ObtenerTodos()
        {
            return applicationDBContext.usuarioRolsCollection.ToList();
        }
    }
}

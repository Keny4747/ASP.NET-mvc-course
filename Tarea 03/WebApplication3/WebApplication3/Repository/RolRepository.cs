using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;

namespace WebApplication3.Repository
{
    public class RolRepository: IRolRepository
    {
        private readonly ApplicationDBContext applicationDBContext;
        public RolRepository(ApplicationDBContext applicationDBContext)
        {
            this.applicationDBContext = applicationDBContext;
        }

        public void Actualizar(RolModel model)
        {
            applicationDBContext.Entry(model).State = EntityState.Modified;
            applicationDBContext.SaveChanges();
        }

        public void Crear(RolModel model)
        {
            applicationDBContext.rolesCollection.Add(model);
            applicationDBContext.SaveChanges();
        }

        public void Eliminar(int id)
        {
            var model = applicationDBContext.rolesCollection.Find(id);
            if (model != null)
            {
                applicationDBContext.rolesCollection.Remove(model);
            }
            applicationDBContext.SaveChangesAsync();
        }

        public RolModel ObtenerPorID(int id)
        {
            return applicationDBContext.rolesCollection.Find(id);
        }

        public List<RolModel> ObtenerTodos()
        {
            return applicationDBContext.rolesCollection.ToList();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;

namespace WebApplication3.Repository
{
    public class DetalleVentaRepository : IDetalleVentaRepository
    {
        private readonly ApplicationDBContext applicationDBContext;
        public DetalleVentaRepository(ApplicationDBContext applicationDBContext)
        {
            this.applicationDBContext = applicationDBContext;
        }

        public void Actualizar(DetalleVentaModel model)
        {
            applicationDBContext.Entry(model).State = EntityState.Modified;
            applicationDBContext.SaveChanges();
        }

        public void Crear(DetalleVentaModel model)
        {
            applicationDBContext.detalleVentasCollection.Add(model);
            applicationDBContext.SaveChanges();
        }

        public void Eliminar(int id)
        {
            var model = applicationDBContext.detalleVentasCollection.Find(id);
            if (model != null)
            {
                applicationDBContext.detalleVentasCollection.Remove(model);
            }
            applicationDBContext.SaveChangesAsync();
        }

        public DetalleVentaModel ObtenerPorID(int id)
        {
            return applicationDBContext.detalleVentasCollection.Find(id);
        }

        public List<DetalleVentaModel> ObtenerTodos()
        {
            return applicationDBContext.detalleVentasCollection.ToList();
        }
    }
}

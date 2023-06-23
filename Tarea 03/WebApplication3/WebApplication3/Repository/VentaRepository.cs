using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;

namespace WebApplication3.Repository
{
    public class VentaRepository : IVentaRepository
    {
        private readonly ApplicationDBContext applicationContext;
        public VentaRepository(ApplicationDBContext applicationContext)
        {
            this.applicationContext = applicationContext;
        }

        public void ActualizarVenta(VentaModel venta)
        {
            applicationContext.Entry(venta).State = EntityState.Modified;
            applicationContext.SaveChanges();
        }

        public void CrearVenta(VentaModel venta)
        {
            applicationContext.ventasCollection.Add(venta);
            applicationContext.SaveChanges();
        }

        public void EliminarVenta(int id)
        {
            var model = applicationContext.ventasCollection.Find(id);
            if (model != null)
            {
                applicationContext.ventasCollection.Remove(model);
            }
            applicationContext.SaveChangesAsync();
        }

        public VentaModel ObtenerPorID(int id)
        {
            return applicationContext.ventasCollection.Find(id);
        }

        public List<VentaModel> ObtenerTodos()
        {
            return applicationContext.ventasCollection.ToList();
        }
    }
}

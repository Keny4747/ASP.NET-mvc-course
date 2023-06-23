using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;

namespace WebApplication3.Repository
{
    public class ProductoRespository : IProductoRepository
    {
        private readonly ApplicationDBContext applicationDBContext;
        public ProductoRespository(ApplicationDBContext applicationDBContext)
        {
            this.applicationDBContext = applicationDBContext;
        }

        public void Actualizar(ProductoModel model)
        {
            applicationDBContext.Entry(model).State = EntityState.Modified;
            applicationDBContext.SaveChanges();
        }

        public void Crear(ProductoModel model)
        {
            applicationDBContext.productosCollection.Add(model);
            applicationDBContext.SaveChanges();
        }

        public void Eliminar(int id)
        {
            var model = applicationDBContext.productosCollection.Find(id);
            if (model != null)
            {
                applicationDBContext.productosCollection.Remove(model);
            }
            applicationDBContext.SaveChangesAsync();
        }

        public bool EstaDisponible(int id)
        {
            return true;
        }

        public ProductoModel ObtenerPorID(int id)
        {
            return applicationDBContext.productosCollection.Find(id);
        }

        public List<ProductoModel> ObtenerTodos()
        {
            return applicationDBContext.productosCollection.ToList();
        }
    }
}

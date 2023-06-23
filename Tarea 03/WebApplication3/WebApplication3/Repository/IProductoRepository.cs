using WebApplication3.Models;

namespace WebApplication3.Repository
{
    public interface IProductoRepository
    {
        ProductoModel ObtenerPorID(int id);
        List<ProductoModel> ObtenerTodos();
        void Crear(ProductoModel venta);
        void Actualizar(ProductoModel venta);
        void Eliminar(int id);
        bool EstaDisponible(int id);
    }
}

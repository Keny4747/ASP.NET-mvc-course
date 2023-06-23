using WebApplication3.Models;

namespace WebApplication3.Repository
{
    public interface IDetalleVentaRepository
    {
        DetalleVentaModel ObtenerPorID(int id);
        List<DetalleVentaModel> ObtenerTodos();
        void Crear(DetalleVentaModel venta);
        void Actualizar(DetalleVentaModel venta);
        void Eliminar(int id);
    }
}

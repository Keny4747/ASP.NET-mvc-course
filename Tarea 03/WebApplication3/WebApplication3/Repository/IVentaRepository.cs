using WebApplication3.Models;

namespace WebApplication3.Repository
{
    public interface IVentaRepository
    {
        VentaModel ObtenerPorID(int id);
        List<VentaModel> ObtenerTodos();
        void CrearVenta(VentaModel venta);
        void ActualizarVenta(VentaModel venta);
        void EliminarVenta(int id);
    }
}

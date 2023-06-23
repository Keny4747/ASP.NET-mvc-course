using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication3.Models
{
    [Table("venta")]
    public class VentaModel
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public List<DetalleVentaModel> detallesVenta { get; set; }
    }
}

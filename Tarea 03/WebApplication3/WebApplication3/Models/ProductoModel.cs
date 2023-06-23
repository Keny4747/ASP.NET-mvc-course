using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication3.Models
{
    [Table("producto")]
    public class ProductoModel
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public double precio { get; set; }
    }
}

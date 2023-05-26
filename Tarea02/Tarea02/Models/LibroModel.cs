using System.ComponentModel.DataAnnotations.Schema;

namespace Tarea02.Models
{
    [Table("libro")]
    public class LibroModel
    {
        public int id { get; set; }
        public string titulo { get; set; }
        public string descripcion { get; set; }
    }
}

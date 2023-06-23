using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationAPI.Models
{
    [Table("libro")]
    public class LibroModel
    {
        public int id { get; set; }
        public string titulo { get; set; }
        public string descripcion { get; set; }
    }
}

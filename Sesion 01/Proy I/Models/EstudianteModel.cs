using System.ComponentModel.DataAnnotations.Schema;

namespace Proy_I.Models
{
    [Table("estudiante")]
    public class EstudianteModel
    {

        public int id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
    }
}

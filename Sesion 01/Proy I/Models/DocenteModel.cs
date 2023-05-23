using System.ComponentModel.DataAnnotations.Schema;

namespace Proy_I.Models
{
    [Table("docente")]
    public class DocenteModel
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }

    }
}

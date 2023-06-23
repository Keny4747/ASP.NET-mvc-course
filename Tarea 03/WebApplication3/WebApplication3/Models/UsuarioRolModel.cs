using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication3.Models
{
    [Table("usuario_rol")]
    public class UsuarioRolModel
    {
        public int id { get; set; }
        public int usuario_id { get; set; }
        public int rol_id { get; set; }
        public UsuarioModel usuario { get; set; }
        public RolModel rol { get; set; }
    }
}

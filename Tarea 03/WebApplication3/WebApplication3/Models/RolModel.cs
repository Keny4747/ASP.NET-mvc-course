using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication3.Models
{
    [Table("rol")]
    public class RolModel
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public ICollection<UsuarioRolModel> usuarioRoles { get; set; }
    }
}

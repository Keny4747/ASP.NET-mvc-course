using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication3.Models
{
    [Table("usuario")]
    public class UsuarioModel
    {
        public int id { get; set; }
        public string usuario { get; set; }
        public string contrasenia { get;set; }
        public ICollection<UsuarioRolModel>? usuarioRoles { get; set; }
        [NotMapped]
        public List<int>? roles { get; set; }
    }
}

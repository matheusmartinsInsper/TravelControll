
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelControll.Models
{
    [Table("usuario")]
    public class UsuarioModel
    {
        [Key]
        public int id_usuario { get; set; }
        public string? email { get; set; }
        public string? senha { get; set; }
        public string? type_usuario { get; set; }
        public string? nome { get; set; }
        public virtual List<FreteModel>? fretes { get; set; }
    }
}

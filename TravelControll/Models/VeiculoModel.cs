using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelControll.Models
{
    [Table("veiculo")]
    public class VeiculoModel
    {
        [Key]
        public int id_veiculo { get; set; }
        public int id_usuario { get; set; }
        public string nome_veiculo { get; set; }
        public int peso_veiculo { get; set; }
        public UsuarioModel UsuarioModel { get; set; }
    }
}

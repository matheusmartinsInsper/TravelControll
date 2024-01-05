using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TravelControll.Models
{
    [Table("veiculo")]
    public class VeiculoModel
    {
        [Key]
        public int? id { get; set; }
        public int id_usuario { get; set; }
        public string nome_veiculo { get; set; }
        public int peso_veiculo { get; set; }
        [JsonIgnore]
        public virtual UsuarioModel? UsuarioModel { get; set; }
        //public  virtual List<VeiculosFretes> FretesVeiculos { get; } = new();
        [JsonIgnore]
        public virtual List<FreteModel>? frete { get; set; }
    }
}

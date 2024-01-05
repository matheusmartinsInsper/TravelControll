using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TravelControll.Models
{
    [Table("carga")]
    public class CargaModel
    {
        [Key]
        public int? id { get; set; }
        public string? nome_carga { get; set; }
        public int? id_empresa { get; set; }
        public float? peso_carga { get; set; }
        public float? massa_carga { get; set; }
        [JsonIgnore]
        public virtual List<FreteModel>? frete { get; set; }

    }
}

using Npgsql.Replication.PgOutput.Messages;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TravelControll.Models
{
    [Table("frete")]
    public class FreteModel
    {
        [Key]
        public int id_frete { get; set; }
        public string origem { get; set; }
        public string destino { get; set; }
        public DateTime data_entrega { get; set; }
        public int id_empresa { get; set; }
        public int? id_motorista { get; set; }
        [JsonIgnore]
        public virtual UsuarioModel UsuarioModel { get; set; }
    }
}

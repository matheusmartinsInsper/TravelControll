using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TravelControll.Models
{
    public class veiculofrete
    {       
        public int veiculoId { get; set; }
       
        public int freteId { get; set; }
        [JsonIgnore]
        public virtual FreteModel FreteModel { get; set; } = null!;
        [JsonIgnore]
        public virtual VeiculoModel VeiculoModel { get; set; } = null!;
    }
}

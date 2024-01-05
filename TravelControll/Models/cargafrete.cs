using System.Text.Json.Serialization;

namespace TravelControll.Models
{
    public class cargafrete
    {
        public int freteid { get; set; }

        public int cargaid { get; set; }
        [JsonIgnore]
        public virtual FreteModel FreteModel { get; set; } = null!;
        [JsonIgnore]
        public virtual CargaModel CargaModel { get; set; } = null!;
    }
}

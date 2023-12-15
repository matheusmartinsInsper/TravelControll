using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelControll.Models
{
    [Table("cargafrete")]
    public class CargaFreteModel
    {
        [Key,Column(Order =0)]
        public int id_frete_emissor { get; set; }
        [Key, Column(Order = 1)]
        public int id_carga_emissor { get; set; }
    }
}

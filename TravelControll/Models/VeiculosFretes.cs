using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelControll.Models
{
    public class VeiculosFretes
    {
        [Key,Column(Order =0)]
        public int id_veiculo { get; set; }
        [Key, Column(Order = 1)]
        public int id_usuarioas { get; set; }
        public FreteModel FreteModel { get; set; }
        public VeiculoModel VeiculoModel { get; set; }
    }
}

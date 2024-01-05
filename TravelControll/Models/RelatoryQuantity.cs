namespace TravelControll.Models
{
    public class RelatoryQuantity
    {
        public string? email { get; set; }
        public int? id_empresa { get; set; }
        public string? status { get; set; }
        public int ? quantidade { get; set; }
        public static implicit operator string(RelatoryQuantity relatory) => $"{relatory.id_empresa},{relatory.status},{relatory.quantidade}";
    }
}

using CsvHelper.Configuration;
using TravelControll.Models;

namespace TravelControll.Services
{
    public class RelatoryQuantityMap:ClassMap<RelatoryQuantity>
    {
        public RelatoryQuantityMap()
        {
            Map(x => x.id_empresa).Index(0).Name("id");
            Map(x => x.status).Index(1).Name("status");
            Map(x => x.quantidade).Index(2).Name("quantidade");
        }
    }
}

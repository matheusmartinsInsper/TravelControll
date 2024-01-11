using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelControll.Models;

namespace TravelControll.Data.ModelMapping
{
    public class MappingVeiculoFrete : IEntityTypeConfiguration<veiculofrete>
    {
        public void Configure(EntityTypeBuilder<veiculofrete> builder)
        {
            builder.HasKey(x=>new {x.freteid,x.veiculoid});

            //builder.HasOne(x => x.VeiculoModel)
            //    .WithMany(x => x.fretes)
            //    .HasForeignKey(x => x.id_veiculo_emissor)
            //    .HasPrincipalKey(x => x.id_veiculo);

            //builder.HasOne(x => x.FreteModel)
            //    .WithMany(x => x.VeiculosFretes)
            //    .HasForeignKey(x => x.id_frete_emissor)
            //    .HasPrincipalKey(x => x.id_frete);
        }
    }
}

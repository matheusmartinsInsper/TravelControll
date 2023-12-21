using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelControll.Models;

namespace TravelControll.Data.ModelMapping
{
    public class MappingVeiculo : IEntityTypeConfiguration<VeiculoModel>
    {
        public void Configure(EntityTypeBuilder<VeiculoModel> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.frete)
                .WithMany(x => x.veiculo);

            builder.HasOne(x => x.UsuarioModel)
                .WithMany()
                .HasForeignKey(x => x.id_usuario)
                .HasPrincipalKey(x => x.id_usuario)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

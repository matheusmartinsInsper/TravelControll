using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Hosting;
using TravelControll.Models;

namespace TravelControll.Data.ModelMapping
{
    public class MappingFrete : IEntityTypeConfiguration<FreteModel>
    {
        public void Configure(EntityTypeBuilder<FreteModel> builder)
        {
            builder.HasKey(x => x.id);

            builder.HasOne(x=>x.UsuarioModel)
                .WithMany(x=>x.fretes)
                .HasForeignKey(x=>x.id_empresa)
                .HasPrincipalKey(x => x.id_usuario)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.veiculo)
                .WithMany(x => x.frete)
                .UsingEntity("veiculofrete");

            builder.HasMany(x => x.carga)
                .WithMany(x => x.frete)
                .UsingEntity(j=>j.ToTable("cargafrete"));
        }
    }
}

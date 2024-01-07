using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelControll.Models;

namespace TravelControll.Data.ModelMapping
{
    public class MappingCarga : IEntityTypeConfiguration<CargaModel>
    {
        public void Configure(EntityTypeBuilder<CargaModel> builder)
        {
            builder.HasKey(x => x.id);

            builder.HasMany(x => x.frete)
                .WithMany(x => x.carga);

            builder.HasOne(x => x.UsuarioModel)
                .WithMany()
                .HasForeignKey(x => x.id_empresa)
                .HasPrincipalKey(x => x.id_usuario)
                .OnDelete(DeleteBehavior.Restrict);
            //builder.HasMany(x => x.frete)
            //    .WithMany(x => x.carga); 
        }
    }
}

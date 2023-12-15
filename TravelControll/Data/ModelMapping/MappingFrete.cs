using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelControll.Models;

namespace TravelControll.Data.ModelMapping
{
    public class MappingFrete : IEntityTypeConfiguration<FreteModel>
    {
        public void Configure(EntityTypeBuilder<FreteModel> builder)
        {
            builder.HasOne(x=>x.UsuarioModel)
                .WithMany(x=>x.fretes)
                .HasForeignKey(x=>x.id_empresa)
                .HasPrincipalKey(x => x.id_usuario)
                .OnDelete(DeleteBehavior.Restrict);      
        }
    }
}

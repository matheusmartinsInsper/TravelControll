using TravelControll.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TravelControll.Data.ModelMapping
{
    public class MappingUsuario : IEntityTypeConfiguration<UsuarioModel>
    {
        public void Configure(EntityTypeBuilder<UsuarioModel> builder)
        {
            builder.HasMany(x=>x.fretes)
                .WithOne(x=>x.UsuarioModel)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelControll.Models;

namespace TravelControll.Data.ModelMapping
{
    public class MappingRelatory : IEntityTypeConfiguration<RelatoryQuantity>
    {
        public void Configure(EntityTypeBuilder<RelatoryQuantity> builder)
        {
            builder.HasNoKey();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClashRoyaleClanWarsAPI.Models.Configurations
{
    public class StructureConfiguration : IEntityTypeConfiguration<StructureModel>
    {
        public void Configure(EntityTypeBuilder<StructureModel> builder)
        {
            builder.Property(c => c.HitPoints).HasColumnName("HitPoints");
            builder.Property(c => c.Radius).HasColumnName("Radius");

        }
    }
}

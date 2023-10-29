using ClashRoyaleClanWarsAPI.Domain.Models.Card.Implementation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClashRoyaleClanWarsAPI.Infrastructure.Persistance.Configurations.Models;

public class StructureConfiguration : IEntityTypeConfiguration<StructureModel>
{
    public void Configure(EntityTypeBuilder<StructureModel> builder)
    {
        builder.Property(c => c.HitPoints).HasColumnName("HitPoints");
        builder.Property(c => c.Radius).HasColumnName("Radius");
        builder.Property(c => c.LifeTime).HasColumnName("LifeTime");
        builder.Property(c => c.Range).HasColumnName("Range");
        builder.Property(c => c.HitSpeed).HasColumnName("HitSpeed");

    }
}

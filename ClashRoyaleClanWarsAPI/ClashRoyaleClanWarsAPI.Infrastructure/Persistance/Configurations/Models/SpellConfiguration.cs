using ClashRoyaleClanWarsAPI.Domain.Models.Card.Implementation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClashRoyaleClanWarsAPI.Infrastructure.Persistance.Configurations.Models;

public class SpellConfiguration : IEntityTypeConfiguration<SpellModel>
{
    public void Configure(EntityTypeBuilder<SpellModel> builder)
    {
        builder.Property(c => c.Radius).HasColumnName("Radius");
        builder.Property(c => c.LifeTime).HasColumnName("LifeTime");
    }
}

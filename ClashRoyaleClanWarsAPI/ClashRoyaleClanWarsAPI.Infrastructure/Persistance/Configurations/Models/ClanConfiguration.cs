using ClashRoyaleClanWarsAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClashRoyaleClanWarsAPI.Infrastructure.Persistance.Configurations.Models;

public class ClanConfiguration : IEntityTypeConfiguration<ClanModel>
{
    public void Configure(EntityTypeBuilder<ClanModel> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Name)
            .HasMaxLength(64)
            .IsRequired();

        builder.Property(c => c.Region)
            .HasMaxLength(32)
            .IsRequired();

        builder.Property(c => c.TrophiesInWar)
            .HasDefaultValue(0);

        builder.Property(c => c.AmountMembers)
            .HasDefaultValue(0);

        builder.Property(c => c.MinTrophies)
            .HasDefaultValue(0);
    }
}

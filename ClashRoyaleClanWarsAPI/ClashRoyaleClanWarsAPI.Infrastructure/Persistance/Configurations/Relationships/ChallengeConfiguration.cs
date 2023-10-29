using ClashRoyaleClanWarsAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClashRoyaleClanWarsAPI.Infrastructure.Persistance.Configurations.Relationships;

public class ChallengeConfiguration : IEntityTypeConfiguration<ChallengeModel>
{
    public void Configure(EntityTypeBuilder<ChallengeModel> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Name)
            .HasMaxLength(32)
            .IsRequired();
    }
}

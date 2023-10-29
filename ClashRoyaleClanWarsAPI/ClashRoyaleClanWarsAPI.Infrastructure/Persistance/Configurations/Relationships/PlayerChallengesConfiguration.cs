using ClashRoyaleClanWarsAPI.Domain.Relationships;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClashRoyaleClanWarsAPI.Infrastructure.Persistance.Configurations.Relationships;

public class PlayerChallengesConfiguration : IEntityTypeConfiguration<ChallengePlayersModel>
{
    public void Configure(EntityTypeBuilder<ChallengePlayersModel> builder)
    {
        builder.Property<int>("PlayerId");
        builder.Property<int>("ChallengeId");

        builder.HasOne(d => d.Player)
            .WithMany()
            .HasForeignKey("PlayerId")
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(d => d.Challenge)
            .WithMany()
            .HasForeignKey("ChallengeId");

        builder.HasKey("PlayerId", "ChallengeId");
    }
}

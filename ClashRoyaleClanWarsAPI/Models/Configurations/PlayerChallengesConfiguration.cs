using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClashRoyaleClanWarsAPI.Models.Configurations
{
    public class PlayerChallengesConfiguration : IEntityTypeConfiguration<PlayerChallengesModel>
    {
        public void Configure(EntityTypeBuilder<PlayerChallengesModel> builder)
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
}

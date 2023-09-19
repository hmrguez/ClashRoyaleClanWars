using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClashRoyaleClanWarsAPI.Models.Configurations
{
    public class PlayerClanConfiguration : IEntityTypeConfiguration<PlayerClansModel>
    {
        public void Configure(EntityTypeBuilder<PlayerClansModel> builder)
        {
            builder.Property<int>("PlayerId");
            builder.Property<int>("ClanId");

            builder.HasOne(d => d.Clan)
                .WithMany()
                .HasForeignKey("ClanId");
            builder.HasOne(d => d.Player)
                .WithMany()
                .HasForeignKey("PlayerId")
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasKey("PlayerId", "ClanId");
        }
    }
}

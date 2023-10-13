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
                .WithMany(d=> d.Players)
                .HasForeignKey("ClanId")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(d => d.Player)
                .WithMany()
                .HasForeignKey("PlayerId")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasKey("PlayerId", "ClanId");
        }
    }
}

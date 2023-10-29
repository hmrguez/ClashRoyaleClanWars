using ClashRoyaleClanWarsAPI.Domain.Relationships;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClashRoyaleClanWarsAPI.Infrastructure.Persistance.Configurations.Relationships;

public class ClanPlayersConfiguration : IEntityTypeConfiguration<ClanPlayersModel>
{
    public void Configure(EntityTypeBuilder<ClanPlayersModel> builder)
    {
        
        builder.Property<int>("PlayerId");
        builder.Property<int>("ClanId");

        builder.HasKey("PlayerId", "ClanId");
        
        builder.HasOne(d => d.Clan)
            .WithMany(d => d.Players)
            .HasForeignKey("ClanId")
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(d => d.Player)
            .WithMany()
            .HasForeignKey("PlayerId")
            .OnDelete(DeleteBehavior.Cascade);

    }
}

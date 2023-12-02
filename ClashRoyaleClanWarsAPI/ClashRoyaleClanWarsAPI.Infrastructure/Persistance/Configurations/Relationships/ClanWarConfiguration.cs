using ClashRoyaleClanWarsAPI.Domain.Relationships;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClashRoyaleClanWarsAPI.Infrastructure.Persistance.Configurations.Relationships;

public class ClanWarsConfiguration : IEntityTypeConfiguration<ClanWarsModel>
{
    public void Configure(EntityTypeBuilder<ClanWarsModel> builder)
    {
        builder.Property<int>("WarId");
        builder.Property<int>("ClanId");

        builder.HasKey("ClanId", "WarId");
        
        builder.HasOne(c => c.War)
            .WithMany(w=> w.ClansInWar)
            .HasForeignKey("WarId");
        
        builder.HasOne(c => c.Clan)
            .WithOne()
            .HasForeignKey<ClanWarsModel>(c=> c.ClanId);

    }
}

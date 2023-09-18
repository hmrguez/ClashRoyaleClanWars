using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClashRoyaleClanWarsAPI.Models.Configurations
{
    public class ClanWarsConfiguration : IEntityTypeConfiguration<ClanWarsModel>
    {
        public void Configure(EntityTypeBuilder<ClanWarsModel> builder)
        {
            builder.Property<int>("WarId");
            builder.Property<int>("ClanId");

            builder.HasOne(c => c.War)
                .WithMany()
                .HasForeignKey("WarId");
            builder.HasOne(c => c.Clan)
                .WithMany()
                .HasForeignKey("ClanId");

            builder.HasKey("ClanId", "WarId");
        }
    }
}

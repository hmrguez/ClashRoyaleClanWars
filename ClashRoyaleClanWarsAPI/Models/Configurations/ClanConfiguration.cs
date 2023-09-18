using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClashRoyaleClanWarsAPI.Models.Configurations
{
    public class ClanConfiguration : IEntityTypeConfiguration<ClanModel>
    {
        public void Configure(EntityTypeBuilder<ClanModel> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name)
                .IsRequired();
            builder.Property(c => c.Region)
                .IsRequired();
            builder.Property(c => c.TrophiesInWar)
                .HasDefaultValue(0);
            builder.Property(c => c.AmountMembers)
                .HasDefaultValue(0);
            builder.Property(c => c.MinTrophies)
                .HasDefaultValue(0);
        }
    }
}

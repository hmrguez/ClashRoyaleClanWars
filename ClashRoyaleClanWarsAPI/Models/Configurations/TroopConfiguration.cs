using ClashRoyaleClanWarsAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClashRoyaleClanWarsAPI.Models.Configurations
{
    public class TroopConfiguration : IEntityTypeConfiguration<TroopModel>
    {
        public void Configure(EntityTypeBuilder<TroopModel> builder)
        {
            builder.Property(c => c.HitPoints).HasColumnName("HitPoints");
            builder.Property(c => c.Range).HasColumnName("Range");
            builder.Property(c => c.HitSpeed).HasColumnName("HitSpeed");
        }
    }
}

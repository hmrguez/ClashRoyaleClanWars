using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClashRoyaleClanWarsAPI.Models.Configurations
{
    public class BattleConfiguration : IEntityTypeConfiguration<BattleModel>
    {
        public void Configure(EntityTypeBuilder<BattleModel> builder)
        {
            builder.HasOne(b => b.Winner)
                .WithMany()
                .HasForeignKey("WinnerId");
        }
    }
}

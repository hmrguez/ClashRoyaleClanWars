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
                .HasForeignKey("WinnerId")
                .OnDelete(DeleteBehavior.NoAction);


            builder.HasOne(b => b.Loser)
                .WithMany()
                .HasForeignKey("LoserId")
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasIndex("WinnerId", "LoserId", "Date").IsUnique();
        }
    }
}

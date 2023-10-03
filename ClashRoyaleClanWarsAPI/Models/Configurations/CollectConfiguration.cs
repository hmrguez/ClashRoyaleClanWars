using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClashRoyaleClanWarsAPI.Models.Configurations
{
    public class CollectConfiguration : IEntityTypeConfiguration<CollectModel>
    {
        public void Configure(EntityTypeBuilder<CollectModel> builder)
        {
            builder.Property<int>("PlayerId");
            builder.Property<int>("CardId");

            builder.HasOne(c => c.Player)
                .WithMany(p => p.Cards)
                .HasForeignKey("PlayerId")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(c => c.Card)
                .WithMany()
                .HasForeignKey("CardId")
                .OnDelete(DeleteBehavior.NoAction);


            builder.HasKey("PlayerId", "CardId");

            
        }
    }
}

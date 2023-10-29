using ClashRoyaleClanWarsAPI.Domain.Relationships;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClashRoyaleClanWarsAPI.Infrastructure.Persistance.Configurations.Relationships;

public class CollectionConfiguration : IEntityTypeConfiguration<CollectionModel>
{
    public void Configure(EntityTypeBuilder<CollectionModel> builder)
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

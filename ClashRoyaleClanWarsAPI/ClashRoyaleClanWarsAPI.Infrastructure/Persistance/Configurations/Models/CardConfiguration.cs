using ClashRoyaleClanWarsAPI.Domain.Enum;
using ClashRoyaleClanWarsAPI.Domain.Models.Card;
using ClashRoyaleClanWarsAPI.Domain.Models.Card.Implementation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClashRoyaleClanWarsAPI.Infrastructure.Persistance.Configurations.Models;

public class CardConfiguration : IEntityTypeConfiguration<CardModel>
{
    public void Configure(EntityTypeBuilder<CardModel> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id)
            .ValueGeneratedNever();

        builder.Property(c => c.Name)
            .HasMaxLength(32)
            .IsRequired();

        builder.Property(c => c.Elixir)
            .IsRequired();

        builder.Property(c => c.Quality)
            .IsRequired();


        builder.HasDiscriminator<TypeCardEnum>("Type")
            .HasValue<CardModel>(TypeCardEnum.Unknown)
            .HasValue<SpellModel>(TypeCardEnum.Spell)
            .HasValue<StructureModel>(TypeCardEnum.Structure)
            .HasValue<TroopModel>(TypeCardEnum.Troop);
    }
}

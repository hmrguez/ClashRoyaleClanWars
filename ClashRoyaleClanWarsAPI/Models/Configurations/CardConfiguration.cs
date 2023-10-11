using ClashRoyaleClanWarsAPI.Data;
using ClashRoyaleClanWarsAPI.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClashRoyaleClanWarsAPI.Models.Configurations
{
    public class CardConfiguration : IEntityTypeConfiguration<CardModel>
    {
        public void Configure(EntityTypeBuilder<CardModel> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(32);
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
}

using ClashRoyaleClanWarsAPI.Data;
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


            builder.HasDiscriminator<DenominationEnum>("Type")
                .HasValue<CardModel>(DenominationEnum.Unknown)
                .HasValue<SpellModel>(DenominationEnum.Spell)
                .HasValue<StructureModel>(DenominationEnum.Structure)
                .HasValue<TroopModel>(DenominationEnum.Troop);
        }
    }
}

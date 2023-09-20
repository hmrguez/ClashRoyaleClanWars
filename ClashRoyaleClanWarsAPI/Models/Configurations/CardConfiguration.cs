using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClashRoyaleClanWarsAPI.Models.Configurations
{
    public class CardConfiguration : IEntityTypeConfiguration<CardModel>
    {
        public void Configure(EntityTypeBuilder<CardModel> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name)
                .IsRequired();
            builder.Property(c => c.Elixir)
                .IsRequired();
            builder.Property(c => c.Quality)
                .IsRequired();


            builder.HasDiscriminator<Denomination>("Type")
                .HasValue<CardModel>(Denomination.Unknown)
                .HasValue<SpellModel>(Denomination.Spell)
                .HasValue<StructureModel>(Denomination.Structure)
                .HasValue<TroopModel>(Denomination.Troop);
        }
    }
}

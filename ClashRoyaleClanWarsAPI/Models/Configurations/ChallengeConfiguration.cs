using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClashRoyaleClanWarsAPI.Models.Configurations
{
    public class ChallengeConfiguration : IEntityTypeConfiguration<ChallengeModel>
    {
        public void Configure(EntityTypeBuilder<ChallengeModel> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name)
                .IsRequired();

        }
    }
}

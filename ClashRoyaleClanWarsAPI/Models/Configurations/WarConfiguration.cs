using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClashRoyaleClanWarsAPI.Models.Configurations
{
    public class WarConfiguration : IEntityTypeConfiguration<WarModel>
    {
        public void Configure(EntityTypeBuilder<WarModel> builder)
        {
            builder.HasKey(w=>w.Id);
        }
    }
}

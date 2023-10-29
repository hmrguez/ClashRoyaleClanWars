using ClashRoyaleClanWarsAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClashRoyaleClanWarsAPI.Infrastructure.Persistance.Configurations.Models;

public class WarConfiguration : IEntityTypeConfiguration<WarModel>
{
    public void Configure(EntityTypeBuilder<WarModel> builder)
    {
        builder.HasKey(w => w.Id);
    }
}

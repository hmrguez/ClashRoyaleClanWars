using ClashRoyaleClanWarsAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClashRoyaleClanWarsAPI.Infrastructure.Persistance.Configurations.Models;

internal class RoleModelConfiguration : IEntityTypeConfiguration<RoleModel>
{
    public void Configure(EntityTypeBuilder<RoleModel> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever();

        builder.Property(x => x.Name)
            .HasMaxLength(32)
            .IsRequired();

        builder.HasIndex(x => x.Name).IsUnique();
    }
}

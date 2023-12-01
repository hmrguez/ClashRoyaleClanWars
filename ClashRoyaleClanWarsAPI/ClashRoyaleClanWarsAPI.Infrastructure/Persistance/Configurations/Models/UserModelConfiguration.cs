using ClashRoyaleClanWarsAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClashRoyaleClanWarsAPI.Infrastructure.Persistance.Configurations.Models;

internal class UserModelConfiguration : IEntityTypeConfiguration<UserModel>
{
    public void Configure(EntityTypeBuilder<UserModel> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x=> x.Id)
            .ValueGeneratedNever();

        builder.Property(u => u.UserName)
            .HasMaxLength(64)
            .IsRequired();

        builder.Property(u => u.PasswordHash)
            .IsRequired();

        builder.HasOne(u => u.Role)
            .WithMany(r=> r.Users)
            .HasForeignKey(u=> u.RoleId)
            .IsRequired();

        builder.HasOne(u => u.Player)
            .WithOne(p => p.User)
            .IsRequired(false);

    }
}

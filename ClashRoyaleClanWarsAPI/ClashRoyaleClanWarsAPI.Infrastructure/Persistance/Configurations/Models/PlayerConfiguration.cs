﻿using ClashRoyaleClanWarsAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClashRoyaleClanWarsAPI.Infrastructure.Persistance.Configurations.Models;

public class PlayerConfiguration : IEntityTypeConfiguration<PlayerModel>
{
    public void Configure(EntityTypeBuilder<PlayerModel> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Alias)
            .HasMaxLength(64)
            .IsRequired();

        builder.Property(p => p.Level)
            .IsRequired()
            .HasDefaultValue(1);

        builder.Property(p => p.Victories)
            .HasDefaultValue(0);

        builder.Property(p => p.CardAmount)
            .HasDefaultValue(0);

        builder.Property(p => p.MaxElo)
            .HasDefaultValue(0);

        builder.Property(p => p.Elo)
            .HasDefaultValue(0);

        builder.HasOne(p => p.FavoriteCard)
            .WithMany()
            .HasForeignKey("FavoriteCardId")
            .IsRequired(false);

        builder.HasOne(u => u.User)
            .WithOne(p => p.Player)
            .HasForeignKey<UserModel>(p => p.PlayerId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.SetNull);
    }
}

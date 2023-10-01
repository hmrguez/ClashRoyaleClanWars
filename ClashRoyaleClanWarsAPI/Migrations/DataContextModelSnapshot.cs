﻿// <auto-generated />
using System;
using ClashRoyaleClanWarsAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ClashRoyaleClanWarsAPI.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ClashRoyaleClanWarsAPI.Models.BattleModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AmountTrophies")
                        .HasColumnType("int");

                    b.Property<int>("DurationInSeconds")
                        .HasColumnType("int");

                    b.Property<int>("WinnerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("WinnerId");

                    b.ToTable("Battles");
                });

            modelBuilder.Entity("ClashRoyaleClanWarsAPI.Models.CardModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("AreaDamage")
                        .HasColumnType("bit");

                    b.Property<int>("Damage")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Elixir")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("InitialLevel")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<int>("Quality")
                        .HasColumnType("int");

                    b.Property<int>("Target")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Cards");

                    b.HasDiscriminator<int>("Type").HasValue(0);

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("ClashRoyaleClanWarsAPI.Models.ChallengeModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AmountReward")
                        .HasColumnType("int");

                    b.Property<int>("Cost")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DurationInHours")
                        .HasColumnType("int");

                    b.Property<int>("LossLimit")
                        .HasColumnType("int");

                    b.Property<int>("MinLevel")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Challenges");
                });

            modelBuilder.Entity("ClashRoyaleClanWarsAPI.Models.ClanModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AmountMembers")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MinTrophies")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("Region")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<int>("TrophiesInWar")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<bool>("TypeOpen")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Clans");
                });

            modelBuilder.Entity("ClashRoyaleClanWarsAPI.Models.ClanWarsModel", b =>
                {
                    b.Property<int>("ClanId")
                        .HasColumnType("int");

                    b.Property<int>("WarId")
                        .HasColumnType("int");

                    b.Property<int>("Prize")
                        .HasColumnType("int");

                    b.HasKey("ClanId", "WarId");

                    b.HasIndex("WarId");

                    b.ToTable("ClanWars");
                });

            modelBuilder.Entity("ClashRoyaleClanWarsAPI.Models.CollectModel", b =>
                {
                    b.Property<int>("PlayerId")
                        .HasColumnType("int");

                    b.Property<int>("CardId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.HasKey("PlayerId", "CardId");

                    b.HasIndex("CardId");

                    b.ToTable("Collection");
                });

            modelBuilder.Entity("ClashRoyaleClanWarsAPI.Models.DonationModel", b =>
                {
                    b.Property<int>("PlayerId")
                        .HasColumnType("int");

                    b.Property<int>("ClanId")
                        .HasColumnType("int");

                    b.Property<int>("CardId")
                        .HasColumnType("int");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.HasKey("PlayerId", "ClanId", "CardId");

                    b.HasIndex("CardId");

                    b.HasIndex("ClanId");

                    b.ToTable("Donations");
                });

            modelBuilder.Entity("ClashRoyaleClanWarsAPI.Models.PlayerChallengesModel", b =>
                {
                    b.Property<int>("PlayerId")
                        .HasColumnType("int");

                    b.Property<int>("ChallengeId")
                        .HasColumnType("int");

                    b.Property<int>("PrizeAmount")
                        .HasColumnType("int");

                    b.HasKey("PlayerId", "ChallengeId");

                    b.HasIndex("ChallengeId");

                    b.ToTable("PlayerChallenges");
                });

            modelBuilder.Entity("ClashRoyaleClanWarsAPI.Models.PlayerClansModel", b =>
                {
                    b.Property<int>("PlayerId")
                        .HasColumnType("int");

                    b.Property<int>("ClanId")
                        .HasColumnType("int");

                    b.Property<int>("Rank")
                        .HasColumnType("int");

                    b.HasKey("PlayerId", "ClanId");

                    b.HasIndex("ClanId");

                    b.ToTable("PlayerClans");
                });

            modelBuilder.Entity("ClashRoyaleClanWarsAPI.Models.PlayerModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Alias")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CardAmount")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<int>("Elo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<int?>("FavoriteCardId")
                        .HasColumnType("int");

                    b.Property<int>("Level")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<int>("MaxElo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<int>("Victories")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.HasKey("Id");

                    b.HasIndex("FavoriteCardId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("ClashRoyaleClanWarsAPI.Models.WarModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Wars");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("Roles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "9c892de0-0c28-4d8e-977d-920f78516d4b",
                            ConcurrencyStamp = "f81816fe-38c1-444c-8c6e-a94cc98d1181",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "697f1925-86eb-43da-8176-37b572fad0c4",
                            ConcurrencyStamp = "c629d09c-b55a-4198-b0d1-9a74793153dd",
                            Name = "User",
                            NormalizedName = "USER"
                        },
                        new
                        {
                            Id = "8fb28309-0ca1-4685-b0a5-9fe3c9f7d5c3",
                            ConcurrencyStamp = "78125589-f9b6-4445-87b0-43371836c475",
                            Name = "SuperAdmin",
                            NormalizedName = "SUPERADMIN"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("Users", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "e429fd44-326c-4164-b60a-5c110136093f",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "7a648fb9-72cf-4eab-9ae2-8f3b6d1188b4",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedUserName = "SUPERADMIN",
                            PasswordHash = "AQAAAAIAAYagAAAAEMsnWf1Epd8g5k988OaNBS5WWx4l0H6J5VD90RX9VnlZTZSfrhUcI4GP6APgejgAFw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "41f4d935-5997-429d-a494-c481289e5341",
                            TwoFactorEnabled = false,
                            UserName = "superadmin"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("UserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "e429fd44-326c-4164-b60a-5c110136093f",
                            RoleId = "8fb28309-0ca1-4685-b0a5-9fe3c9f7d5c3"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("UserTokens", (string)null);
                });

            modelBuilder.Entity("ClashRoyaleClanWarsAPI.Models.SpellModel", b =>
                {
                    b.HasBaseType("ClashRoyaleClanWarsAPI.Models.CardModel");

                    b.Property<int>("LifeTime")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("int")
                        .HasColumnName("LifeTime");

                    b.Property<float>("Radius")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("real")
                        .HasColumnName("Radius");

                    b.Property<int>("TowerDamage")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue(1);
                });

            modelBuilder.Entity("ClashRoyaleClanWarsAPI.Models.StructureModel", b =>
                {
                    b.HasBaseType("ClashRoyaleClanWarsAPI.Models.CardModel");

                    b.Property<int>("HitPoints")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("int")
                        .HasColumnName("HitPoints");

                    b.Property<float>("HitSpeed")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("real")
                        .HasColumnName("HitSpeed");

                    b.Property<int>("LifeTime")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("int")
                        .HasColumnName("LifeTime");

                    b.Property<float>("Radius")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("real")
                        .HasColumnName("Radius");

                    b.Property<float>("Range")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("real")
                        .HasColumnName("Range");

                    b.HasDiscriminator().HasValue(2);
                });

            modelBuilder.Entity("ClashRoyaleClanWarsAPI.Models.TroopModel", b =>
                {
                    b.HasBaseType("ClashRoyaleClanWarsAPI.Models.CardModel");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int>("HitPoints")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("int")
                        .HasColumnName("HitPoints");

                    b.Property<float>("HitSpeed")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("real")
                        .HasColumnName("HitSpeed");

                    b.Property<float>("Range")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("real")
                        .HasColumnName("Range");

                    b.Property<int>("Speed")
                        .HasColumnType("int");

                    b.Property<int>("Transport")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue(3);
                });

            modelBuilder.Entity("ClashRoyaleClanWarsAPI.Models.BattleModel", b =>
                {
                    b.HasOne("ClashRoyaleClanWarsAPI.Models.PlayerModel", "Winner")
                        .WithMany()
                        .HasForeignKey("WinnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Winner");
                });

            modelBuilder.Entity("ClashRoyaleClanWarsAPI.Models.ClanWarsModel", b =>
                {
                    b.HasOne("ClashRoyaleClanWarsAPI.Models.ClanModel", "Clan")
                        .WithMany()
                        .HasForeignKey("ClanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClashRoyaleClanWarsAPI.Models.WarModel", "War")
                        .WithMany()
                        .HasForeignKey("WarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Clan");

                    b.Navigation("War");
                });

            modelBuilder.Entity("ClashRoyaleClanWarsAPI.Models.CollectModel", b =>
                {
                    b.HasOne("ClashRoyaleClanWarsAPI.Models.CardModel", "Card")
                        .WithMany()
                        .HasForeignKey("CardId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("ClashRoyaleClanWarsAPI.Models.PlayerModel", "Player")
                        .WithMany("Cards")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Card");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("ClashRoyaleClanWarsAPI.Models.DonationModel", b =>
                {
                    b.HasOne("ClashRoyaleClanWarsAPI.Models.CardModel", "Card")
                        .WithMany()
                        .HasForeignKey("CardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClashRoyaleClanWarsAPI.Models.ClanModel", "Clan")
                        .WithMany()
                        .HasForeignKey("ClanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClashRoyaleClanWarsAPI.Models.PlayerModel", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Card");

                    b.Navigation("Clan");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("ClashRoyaleClanWarsAPI.Models.PlayerChallengesModel", b =>
                {
                    b.HasOne("ClashRoyaleClanWarsAPI.Models.ChallengeModel", "Challenge")
                        .WithMany()
                        .HasForeignKey("ChallengeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClashRoyaleClanWarsAPI.Models.PlayerModel", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Challenge");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("ClashRoyaleClanWarsAPI.Models.PlayerClansModel", b =>
                {
                    b.HasOne("ClashRoyaleClanWarsAPI.Models.ClanModel", "Clan")
                        .WithMany()
                        .HasForeignKey("ClanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClashRoyaleClanWarsAPI.Models.PlayerModel", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Clan");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("ClashRoyaleClanWarsAPI.Models.PlayerModel", b =>
                {
                    b.HasOne("ClashRoyaleClanWarsAPI.Models.CardModel", "FavoriteCard")
                        .WithMany()
                        .HasForeignKey("FavoriteCardId");

                    b.Navigation("FavoriteCard");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ClashRoyaleClanWarsAPI.Models.PlayerModel", b =>
                {
                    b.Navigation("Cards");
                });
#pragma warning restore 612, 618
        }
    }
}

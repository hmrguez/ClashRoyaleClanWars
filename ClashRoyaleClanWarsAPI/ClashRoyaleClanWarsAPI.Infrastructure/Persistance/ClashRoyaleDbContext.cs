using ClashRoyaleClanWarsAPI.Domain.Models;
using ClashRoyaleClanWarsAPI.Domain.Models.Battle;
using ClashRoyaleClanWarsAPI.Domain.Models.Card;
using ClashRoyaleClanWarsAPI.Domain.Models.Card.Implementation;
using ClashRoyaleClanWarsAPI.Domain.Relationships;
using ClashRoyaleClanWarsAPI.Infrastructure.Persistance.Configurations.Models;
using ClashRoyaleClanWarsAPI.Infrastructure.Persistance.Configurations.Relationships;
using ClashRoyaleClanWarsAPI.Infrastructure.Persistance.Seed;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ClashRoyaleClanWarsAPI.Infrastructure.Persistance;

public class ClashRoyaleDbContext : IdentityDbContext
{
    private readonly IConfiguration _configuration;
    public ClashRoyaleDbContext(DbContextOptions<ClashRoyaleDbContext> options, IConfiguration configuration) : base(options)
    {
        _configuration = configuration;
    }

    public DbSet<BattleModel> Battles => Set<BattleModel>();
    public DbSet<CardModel> Cards => Set<CardModel>();
    public DbSet<ChallengeModel> Challenges => Set<ChallengeModel>();
    public DbSet<ClanModel> Clans => Set<ClanModel>();
    public DbSet<ClanWarsModel> ClanWars => Set<ClanWarsModel>();
    public DbSet<CollectionModel> Collection => Set<CollectionModel>();
    public DbSet<DonationModel> Donations => Set<DonationModel>();
    public DbSet<ChallengePlayersModel> ChallengePlayers => Set<ChallengePlayersModel>();
    public DbSet<ClanPlayersModel> ClanPlayers => Set<ClanPlayersModel>();
    public DbSet<PlayerModel> Players => Set<PlayerModel>();
    public DbSet<SpellModel> Spells => Set<SpellModel>();
    public DbSet<StructureModel> Structures => Set<StructureModel>();
    public DbSet<TroopModel> Troops => Set<TroopModel>();
    public DbSet<WarModel> Wars => Set<WarModel>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        ApplyModelsConfiguration(modelBuilder);
        ApplyRelationshipsConfiguration(modelBuilder);
        RenameIdentityTables(modelBuilder);

        modelBuilder.SeedRoles(_configuration["SuperAdmin:Password"]!);
        modelBuilder.SeedCards();

    }
    private static void ApplyRelationshipsConfiguration(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ClanWarsConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CollectionConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DonationConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PlayerChallengesConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ClanPlayersConfiguration).Assembly);
    }

    private static void ApplyModelsConfiguration(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BattleConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CardConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ChallengeConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ClanConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PlayerConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TroopConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SpellConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(StructureConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(WarConfiguration).Assembly);
    }

    private static void RenameIdentityTables(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<IdentityUser>(m => m.ToTable("Users"));
        modelBuilder.Entity<IdentityRole>(m => m.ToTable("Roles"));
        modelBuilder.Entity<IdentityRoleClaim<string>>(m => m.ToTable("RoleClaims"));
        modelBuilder.Entity<IdentityUserClaim<string>>(m => m.ToTable("UserClaims"));
        modelBuilder.Entity<IdentityUserLogin<string>>(m => m.ToTable("UserLogins"));
        modelBuilder.Entity<IdentityUserRole<string>>(m => m.ToTable("UserRoles"));
        modelBuilder.Entity<IdentityUserToken<string>>(m => m.ToTable("UserTokens"));
    }
}

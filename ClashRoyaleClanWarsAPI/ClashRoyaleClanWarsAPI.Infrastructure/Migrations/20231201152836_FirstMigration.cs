using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ClashRoyaleClanWarsAPI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Elixir = table.Column<int>(type: "int", nullable: false),
                    Quality = table.Column<int>(type: "int", nullable: false),
                    Damage = table.Column<int>(type: "int", nullable: false),
                    AreaDamage = table.Column<bool>(type: "bit", nullable: false),
                    Target = table.Column<int>(type: "int", nullable: false),
                    InitialLevel = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Radius = table.Column<float>(type: "real", nullable: true),
                    TowerDamage = table.Column<int>(type: "int", nullable: true),
                    LifeTime = table.Column<int>(type: "int", nullable: true),
                    HitPoints = table.Column<int>(type: "int", nullable: true),
                    HitSpeed = table.Column<float>(type: "real", nullable: true),
                    Range = table.Column<float>(type: "real", nullable: true),
                    Amount = table.Column<int>(type: "int", nullable: true),
                    Speed = table.Column<int>(type: "int", nullable: true),
                    Transport = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Challenges",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cost = table.Column<int>(type: "int", nullable: false),
                    AmountReward = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DurationInHours = table.Column<int>(type: "int", nullable: false),
                    IsOpen = table.Column<bool>(type: "bit", nullable: false),
                    MinLevel = table.Column<int>(type: "int", nullable: false),
                    LossLimit = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Challenges", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Region = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    TypeOpen = table.Column<bool>(type: "bit", nullable: false),
                    AmountMembers = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    TrophiesInWar = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    MinTrophies = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Wars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Alias = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Elo = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Level = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    Victories = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    CardAmount = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    MaxElo = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    FavoriteCardId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Players_Cards_FavoriteCardId",
                        column: x => x.FavoriteCardId,
                        principalTable: "Cards",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ClanWars",
                columns: table => new
                {
                    ClanId = table.Column<int>(type: "int", nullable: false),
                    WarId = table.Column<int>(type: "int", nullable: false),
                    Prize = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClanWars", x => new { x.ClanId, x.WarId });
                    table.ForeignKey(
                        name: "FK_ClanWars_Clans_ClanId",
                        column: x => x.ClanId,
                        principalTable: "Clans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClanWars_Wars_WarId",
                        column: x => x.WarId,
                        principalTable: "Wars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Battles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AmountTrophies = table.Column<int>(type: "int", nullable: false),
                    WinnerId = table.Column<int>(type: "int", nullable: true),
                    LoserId = table.Column<int>(type: "int", nullable: true),
                    DurationInSeconds = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Battles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Battles_Players_LoserId",
                        column: x => x.LoserId,
                        principalTable: "Players",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Battles_Players_WinnerId",
                        column: x => x.WinnerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClanPlayers",
                columns: table => new
                {
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    ClanId = table.Column<int>(type: "int", nullable: false),
                    Rank = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClanPlayers", x => new { x.PlayerId, x.ClanId });
                    table.ForeignKey(
                        name: "FK_ClanPlayers_Clans_ClanId",
                        column: x => x.ClanId,
                        principalTable: "Clans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClanPlayers_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Collection",
                columns: table => new
                {
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    CardId = table.Column<int>(type: "int", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collection", x => new { x.PlayerId, x.CardId });
                    table.ForeignKey(
                        name: "FK_Collection_Cards_CardId",
                        column: x => x.CardId,
                        principalTable: "Cards",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Collection_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Donations",
                columns: table => new
                {
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    ClanId = table.Column<int>(type: "int", nullable: false),
                    CardId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donations", x => new { x.PlayerId, x.ClanId, x.CardId, x.Date });
                    table.ForeignKey(
                        name: "FK_Donations_Cards_CardId",
                        column: x => x.CardId,
                        principalTable: "Cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Donations_Clans_ClanId",
                        column: x => x.ClanId,
                        principalTable: "Clans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Donations_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PlayerChallenges",
                columns: table => new
                {
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    ChallengeId = table.Column<int>(type: "int", nullable: false),
                    PrizeAmount = table.Column<int>(type: "int", nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerChallenges", x => new { x.PlayerId, x.ChallengeId });
                    table.ForeignKey(
                        name: "FK_PlayerChallenges_Challenges_ChallengeId",
                        column: x => x.ChallengeId,
                        principalTable: "Challenges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerChallenges_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PlayerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "Id", "Amount", "AreaDamage", "Damage", "Description", "Elixir", "HitPoints", "HitSpeed", "ImageUrl", "InitialLevel", "Name", "Quality", "Range", "Speed", "Target", "Transport", "Type" },
                values: new object[,]
                {
                    { 1, 1, false, 79, "A tough melee fighter. The Barbarian's handsome, cultured cousin. Rumor has it that he was knighted based on the sheer awesomeness of his mustache alone.", 3, 690, 1.2f, "https://api-assets.clashroyale.com/cards/300/jAj1Q5rclXxU9kVImGqSJxa4wEMfEhvwNQ_4jiGUuqg.png", 1, "Knight", 0, 1.2f, 2, 0, 0, 3 },
                    { 2, 2, false, 42, "A pair of lightly armored ranged attackers. They'll help you take down ground and air units, but you're on your own with hair coloring advice.", 3, 119, 0.9f, "https://api-assets.clashroyale.com/cards/300/W4Hmp8MTSdXANN8KdblbtHwtsbt0o749BbxNqmJYfA8.png", 1, "Archers", 0, 5f, 2, 3, 0, 3 },
                    { 3, 4, false, 47, "Four fast, unarmored melee attackers. Small, fast, green and mean!", 2, 79, 1.1f, "https://api-assets.clashroyale.com/cards/300/X_DQUye_OaS3QN6VC9CPw05Fit7wvSm3XegXIXKP--0.png", 1, "Goblins", 0, 0.5f, 4, 0, 0, 3 },
                    { 4, 1, false, 120, "Slow but durable, only attacks buildings. A real one-man wrecking crew!", 5, 1930, 1.5f, "https://api-assets.clashroyale.com/cards/300/Axr4ox5_b7edmLsoHxBX3vmgijAIibuF6RImTbqLlXE.png", 3, "Giant", 1, 1.2f, 1, 2, 0, 3 },
                    { 5, 1, false, 510, "A heavily armored, slow melee fighter. Swings from the hip, but packs a huge punch.", 7, 2350, 1.8f, "https://api-assets.clashroyale.com/cards/300/MlArURKhn_zWAZY-Xj1qIRKLVKquarG25BXDjUQajNs.png", 6, "P.E.K.K.A", 2, 1.2f, 1, 0, 0, 3 },
                    { 6, 3, false, 46, "Three fast, unarmored flying attackers. Roses are red, minions are blue, they can fly, and will crush you!", 3, 90, 1f, "https://api-assets.clashroyale.com/cards/300/yHGpoEnmUWPGV_hBbhn-Kk-Bs838OjGzWzJJlQpQKQA.png", 1, "Minions", 0, 1.6f, 3, 3, 1, 3 },
                    { 7, 1, false, 400, "As pretty as they are, you won't want a parade of THESE balloons showing up on the horizon. Drops powerful bombs and when shot down, crashes dealing area damage.", 5, 1050, 2f, "https://api-assets.clashroyale.com/cards/300/qBipxLo-3hhCnPrApp2Nn3b2NgrSrvwzWytvREev0CY.png", 6, "Ballon", 2, 0.1f, 2, 2, 1, 3 },
                    { 8, 1, true, 84, "Summons Skeletons, shoots destructo beams, has glowing pink eyes that unfortunately don't shoot lasers.", 5, 524, 1.1f, "https://api-assets.clashroyale.com/cards/300/cfwk1vzehVyHC-uloEIH6NOI0hOdofCutR5PyhIgO6w.png", 6, "Witch", 2, 5.5f, 2, 3, 0, 3 },
                    { 9, 5, false, 75, "A horde of melee attackers with mean mustaches and even meaner tempers", 5, 262, 1.3f, "https://api-assets.clashroyale.com/cards/300/TvJsuu2S4yhyk1jVYUAQwdKOnW4U77KuWWOTPOWnwfI.png", 1, "Barbarians", 0, 0.7f, 2, 0, 0, 3 },
                    { 10, 1, false, 195, "Slow but durable, only attacks buildings. When destroyed, explosively splits into two Golemites and deals area damage!", 8, 3200, 2.5f, "https://api-assets.clashroyale.com/cards/300/npdmCnET7jmVjJvjJQkFnNSNnDxYHDBigbvIAloFMds.png", 6, "Golem", 2, 0.75f, 1, 2, 0, 3 },
                    { 11, 3, false, 32, "Three fast, very weak melee fighters. Surround your enemies with this pile of bones!", 1, 32, 1f, "https://api-assets.clashroyale.com/cards/300/oO7iKMU5m0cdxhYPZA3nWQiAUh2yoGgdThLWB1rVSec.png", 1, "Skeletons", 0, 0.5f, 3, 0, 0, 3 },
                    { 12, 1, true, 126, "Tough melee fighter, deals area damage around her. Swarm or horde, no problem! She can take them all out with a few spins.", 4, 900, 1.5f, "https://api-assets.clashroyale.com/cards/300/0lIoYf3Y_plFTzo95zZL93JVxpfb3MMgFDDhgSDGU9A.png", 3, "Valkyrie", 1, 1.2f, 2, 0, 0, 3 },
                    { 13, 15, false, 51, "Spawns an army of Skeletons. Meet Larry and his friends Harry, Terry, Gerry, Mary, etc.", 3, 51, 1f, "https://api-assets.clashroyale.com/cards/300/fAOToOi1pRy7svN2xQS6mDkhQw2pj9m_17FauaNqyl4.png", 6, "Skeleton Army", 2, 0.5f, 3, 0, 0, 3 },
                    { 14, 1, true, 87, "Small, lightly protected skeleton who throws bombs. Deals area damage that can wipe out a swarm of enemies.", 2, 130, 1.8f, "https://api-assets.clashroyale.com/cards/300/12n1CesxKIcqVYntjxcF36EFA-ONw7Z-DoL0_rQrbdo.png", 1, "Bomber", 0, 4.5f, 2, 0, 0, 3 },
                    { 15, 1, false, 103, "Don't be fooled by her delicately coiffed hair, the Musketeer is a mean shot with her trusty boomstick.", 4, 340, 1f, "https://api-assets.clashroyale.com/cards/300/Tex1C48UTq9FKtAX-3tzG0FJmc9jzncUZG3bb5Vf-Ds.png", 3, "Musketeer", 1, 6f, 2, 3, 0, 3 },
                    { 16, 1, true, 100, "Burps fireballs from the sky that deal area damage. Baby dragons hatch cute, hungry and ready for a barbeque.", 4, 720, 1.5f, "https://api-assets.clashroyale.com/cards/300/cjC9n4AvEZJ3urkVh-rwBkJ-aRSsydIMqSAV48hAih0.png", 6, "Baby Dragon", 2, 3.5f, 3, 3, 1, 3 },
                    { 17, 1, false, 245, "Don't let the little pony fool you. Once the Prince gets a running start, you WILL be trampled. Deals double damage once he gets charging.", 5, 1200, 1.4f, "https://api-assets.clashroyale.com/cards/300/3JntJV62aY0G1Qh6LIs-ek-0ayeYFY3VItpG7cb9I60.png", 6, "Prince", 2, 1.6f, 2, 0, 0, 3 },
                    { 18, 1, true, 133, "The most awesome man to ever set foot in the Arena, the Wizard will blow you away with his handsomeness... and/or fireballs.", 4, 340, 1.4f, "https://api-assets.clashroyale.com/cards/300/Mej7vnv4H_3p_8qPs_N6_GKahy6HDr7pU7i9eTHS84U.png", 3, "Wizard", 1, 5.5f, 2, 3, 0, 3 },
                    { 19, 1, false, 340, "The Arena is a certified butterfly-free zone. No distractions for P.E.K.K.A, only destruction.", 4, 642, 1.6f, "https://api-assets.clashroyale.com/cards/300/Fmltc4j3Ve9vO_xhHHPEO3PRP3SmU2oKp2zkZQHRZT4.png", 3, "Mini P.E.K.K.A", 1, 0.8f, 3, 0, 0, 3 },
                    { 20, 3, false, 32, "Three unarmored ranged attackers. Who the heck taught these guys to throw spears!? Who thought that was a good idea?!", 2, 52, 1.7f, "https://api-assets.clashroyale.com/cards/300/FSDFotjaXidI4ku_WFpVCTWS1hKGnFh1sxX0lxM43_E.png", 1, "Spear Goblins", 0, 5.5f, 4, 3, 0, 3 },
                    { 21, 1, false, 167, "The bigger the skeleton, the bigger the bomb. Carries a bomb that blows up when the Giant Skeleton dies.", 6, 2140, 1.4f, "https://api-assets.clashroyale.com/cards/300/0p0gd0XaVRu1Hb1iSG1hTYbz2AN6aEiZnhaAib5O8Z8.png", 6, "Giant Skeleton", 2, 0.8f, 2, 0, 0, 3 },
                    { 22, 1, false, 150, "Fast melee troop that targets buildings and can jump over the river. He followed the echoing call of \"Hog Riderrrrr\" all the way through the Arena doors.", 4, 800, 1.6f, "https://api-assets.clashroyale.com/cards/300/Ubu0oUl8tZkusnkZf8Xv9Vno5IO29Y-jbZ4fhoNJ5oc.png", 3, "Hog Rider", 1, 0.8f, 4, 2, 0, 3 },
                    { 23, 6, false, 46, "Six fast, unarmored flying attackers. Three's a crowd, six is a horde!", 5, 90, 1f, "https://api-assets.clashroyale.com/cards/300/Wyjq5l0IXHTkX9Rmpap6HaH08MvjbxFp1xBO9a47YSI.png", 1, "Minion Horde", 0, 1.6f, 3, 3, 1, 3 },
                    { 24, 1, true, 75, "This chill caster throws ice shards that slow down enemies' movement and attack speed. Despite being freezing cold, he has a handlebar mustache that's too hot for TV.", 3, 569, 1.7f, "https://api-assets.clashroyale.com/cards/300/W3dkw0HTw9n1jB-zbknY2w3wHuyuLxSRIAV5fUT1SEY.png", 9, "Ice Wizard", 3, 5.5f, 2, 3, 0, 3 },
                    { 25, 1, false, 120, "Destroying enemy buildings with his massive cannon is his job; making a raggedy blond beard look good is his passion.", 6, 1200, 1.7f, "https://api-assets.clashroyale.com/cards/300/mnlRaNtmfpQx2e6mp70sLd0ND-pKPF70Cf87_agEKg4.png", 1, "Royal Giant", 0, 5f, 1, 2, 0, 3 },
                    { 26, 3, false, 76, "Three ruthless bone brothers with shields. Knock off their shields and all that's left are three ruthless bone brothers.", 3, 51, 1f, "https://api-assets.clashroyale.com/cards/300/1ArKfLJxYo6_NU_S9cAeIrfbXqWH0oULVJXedxBXQlU.png", 6, "Guards", 2, 1.6f, 3, 0, 0, 3 },
                    { 27, 1, true, 140, "This stunning Princess shoots flaming arrows from long range. If you're feeling warm feelings towards her, it's probably because you're on fire.", 3, 216, 3f, "https://api-assets.clashroyale.com/cards/300/bAwMcqp9EKVIKH3ZLm_m0MqZFSG72zG-vKxpx8aKoVs.png", 9, "Princess", 3, 9f, 2, 3, 0, 3 },
                    { 28, 1, true, 155, "The Dark Prince deals area damage and lets his spiked club do the talking for him - because when he does talk, it sounds like he has a bucket on his head.", 4, 750, 1.3f, "https://api-assets.clashroyale.com/cards/300/M7fXlrKXHu2IvpSGpk36kXVstslbR08Bbxcy0jQcln8.png", 6, "Dark Prince", 2, 1.2f, 2, 0, 0, 3 },
                    { 29, 3, false, 103, "Trio of powerful, independent markswomen, fighting for justice and honor. Disrespecting them would not be just a mistake, it would be a cardinal sin!", 9, 340, 1f, "https://api-assets.clashroyale.com/cards/300/_J2GhbkX3vswaFk1wG-dopwiHyNc_YiPhwroiKF3Mek.png", 3, "Three Musketeer", 1, 6f, 2, 3, 0, 3 },
                    { 30, 1, false, 45, "The Lava Hound is a majestic flying beast that attacks buildings. The Lava Pups are less majestic angry babies that attack anything.", 7, 3150, 1.3f, "https://api-assets.clashroyale.com/cards/300/unicRQ975sBY2oLtfgZbAI56ZvaWz7azj-vXTLxc0r8.png", 9, "Lava Hound", 3, 3.5f, 1, 2, 1, 3 },
                    { 31, 1, true, 43, "Spawns one lively little Ice Spirit to freeze a group of enemies. Stay frosty", 1, 90, 1f, "https://api-assets.clashroyale.com/cards/300/lv1budiafU9XmSdrDkk0NYyqASAFYyZ06CPysXKZXlA.png", 1, "Ice Spirit", 0, 2.5f, 4, 3, 0, 3 },
                    { 32, 1, true, 81, "The Fire Spirit is on a kamikaze mission to give you a warm hug. It'd be adorable if it wasn't on fire", 1, 90, 1f, "https://api-assets.clashroyale.com/cards/300/16-BqusVvynIgYI8_Jci3LDC-r8AI_xaIYLgXqtlmS8.png", 1, "Fire Spirit", 0, 2f, 4, 3, 0, 3 },
                    { 33, 1, false, 160, "The Miner can burrow his way underground and appear anywhere in the Arena. It's not magic, it's a shovel. A shovel that deals reduced damage to Crown Towers.", 3, 1000, 1.2f, "https://api-assets.clashroyale.com/cards/300/Y4yWvdwBCg2FpAZgs8T09Gy34WOwpLZW-ttL52Ae8NE.png", 9, "Miner", 3, 1.2f, 3, 0, 0, 3 },
                    { 34, 1, true, 1100, "Sparky slowly charges up, then unloads MASSIVE area damage. Overkill isn't in her vocabulary.", 6, 1200, 4f, "https://api-assets.clashroyale.com/cards/300/2GKMkBrArZXgQxf2ygFjDs4VvGYPbx8F6Lj_68iVhIM.png", 9, "Sparky", 3, 5f, 1, 0, 0, 3 },
                    { 35, 1, true, 180, "This big blue dude digs the simple things in life - Dark Elixir drinks and throwing rocks. His massive boulders roll through their target, hitting everything behind for a strike!", 5, 1300, 2.5f, "https://api-assets.clashroyale.com/cards/300/SU4qFXmbQXWjvASxVI6z9IJuTYolx4A0MKK90sTIE88.png", 6, "Bowler", 2, 4f, 1, 0, 0, 3 },
                    { 36, 1, false, 200, "He chops trees by day and hunts The Log by night. His bottle of Rage spills everywhere when he's defeated.", 4, 1060, 0.8f, "https://api-assets.clashroyale.com/cards/300/E6RWrnCuk13xMX5OE1EQtLEKTZQV6B78d00y8PlXt6Q.png", 9, "Lumberjack", 3, 0.7f, 4, 0, 0, 3 },
                    { 37, 1, false, 135, "Two Barbarians holding a big log charge at the nearest building, dealing significant damage if they connect; then they go to town with their swords!", 4, 456, 1f, "https://api-assets.clashroyale.com/cards/300/dyc50V2cplKi4H7pq1B3I36pl_sEH5DQrNHboS_dbbM.png", 3, "Battle Ram", 1, 0.5f, 2, 2, 0, 3 },
                    { 38, 1, false, 30, "Shoots a focused beam of fire that increases in damage over time. Wears a helmet because flying can be dangerous.", 4, 1070, 0.4f, "https://api-assets.clashroyale.com/cards/300/y5HDbKtTbWG6En6TGWU0xoVIGs1-iQpIP4HC-VM7u8A.png", 9, "Inferno Dragon", 3, 3.5f, 2, 3, 1, 3 },
                    { 39, 1, false, 40, "He's tough, targets buildings and explodes when destroyed, slowing nearby enemies. Made entirely out of ice... or is he?! Yes.", 2, 565, 0.4f, "https://api-assets.clashroyale.com/cards/300/r05cmpwV1o7i7FHodtZwW3fmjbXCW34IJCsDEV5cZC4.png", 3, "Ice Golem", 1, 3.5f, 1, 2, 0, 3 },
                    { 40, 1, false, 147, "Flying, armored and powerful. What could be its weakness?! Cupcakes.", 3, 395, 1.5f, "https://api-assets.clashroyale.com/cards/300/-T_e4YLbuhPBKbYnBwQfXgynNpp5eOIN_0RracYwL9c.png", 3, "Mega Minion", 1, 1.6f, 2, 3, 1, 3 },
                    { 41, 1, false, 62, "Runs fast, shoots far and chews gum. How does he blow darts with a mouth full of Double Trouble gum? Years of didgeridoo lessons.", 3, 123, 0.7f, "https://api-assets.clashroyale.com/cards/300/BmpK3bqEAviflqHCdxxnfm-_l3pRPJw3qxHkwS55nCY.png", 3, "Dart Goblin", 1, 6.5f, 4, 3, 0, 3 },
                    { 42, 6, false, 47, "Spawns Six Goblins - three with knives, three with spears - at a discounted Elixir cost. It's like a Goblin Value Pack!", 3, 79, 1.1f, "https://api-assets.clashroyale.com/cards/300/NHflxzVAQT4oAz7eDfdueqpictb5vrWezn1nuqFhE4w.png", 1, "Goblin Gang", 0, 9.5f, 4, 3, 0, 3 },
                    { 43, 1, false, 182, "He lands with a \"POW!\", stuns nearby enemies and shoots lightning with both hands! What a show off.", 4, 590, 1.8f, "https://api-assets.clashroyale.com/cards/300/RsFaHgB3w6vXsTjXdPr3x8l_GbV9TbOUCvIx07prbrQ.png", 9, "Electro Wizard", 3, 5f, 3, 3, 0, 3 },
                    { 44, 2, false, 150, "Spawns a pair of leveled up Barbarians. They're like regular Barbarians, only harder, better, faster and stronger.", 6, 524, 1.4f, "https://api-assets.clashroyale.com/cards/300/C88C5JH_F3lLZj6K-tLcMo5DPjrFmvzIb1R2M6xCfTE.png", 1, "Elite Barbarians", 0, 1.2f, 3, 0, 0, 3 },
                    { 45, 1, true, 530, "He deals BIG damage up close - not so much at range. What he lacks in accuracy, he makes up for with his impressively bushy eyebrows.", 4, 524, 2.2f, "https://api-assets.clashroyale.com/cards/300/VNabB1WKnYtYRSG7X_FZfnZjQDHTBs9A96OGMFmecrA.png", 6, "Hunter", 2, 4f, 2, 3, 0, 3 },
                    { 46, 1, true, 212, "He throws his axe like a boomerang, striking all enemies on the way out AND back. It's a miracle he doesn't lose an arm.", 5, 800, 0.9f, "https://api-assets.clashroyale.com/cards/300/9XL5BP2mqzV8kza6KF8rOxrpCZTyuGLp2l413DTjEoM.png", 6, "Executioner", 2, 4.5f, 2, 3, 0, 3 },
                    { 47, 1, false, 160, "The Bandit dashes to her target and delivers an extra big hit! While dashing, she can't be touched. The mask keeps her identity safe, and gives her bonus cool points!", 3, 750, 1f, "https://api-assets.clashroyale.com/cards/300/QWDdXMKJNpv0go-HYaWQWP6p8uIOHjqn-zX7G0p3DyM.png", 9, "Bandit", 3, 0.75f, 3, 0, 0, 3 },
                    { 48, 6, false, 52, "Deploys a line of recruits armed with spears, shields and wooden buckets. They dream of ponies and one day wearing metal buckets.", 7, 208, 1.3f, "https://api-assets.clashroyale.com/cards/300/jcNyYGUiXXNz3kuz8NBkHNKNREQKraXlb_Ts7rhCIdM.png", 1, "Royal Recruits", 0, 1.6f, 2, 0, 0, 3 },
                    { 49, 1, false, 260, "Summons Bats to do her bidding! If you get too close, she's not afraid of pitching in with her mean-looking battle staff.", 4, 750, 1.3f, "https://api-assets.clashroyale.com/cards/300/NpCrXDEDBBJgNv9QrBAcJmmMFbS7pe3KCY8xJ5VB18A.png", 9, "Night Witch", 3, 1.6f, 2, 0, 0, 3 },
                    { 50, 5, false, 32, "Spawns a handful of tiny flying creatures. Think of them as sweet, purple... balls of DESTRUCTION!", 2, 32, 1.3f, "https://api-assets.clashroyale.com/cards/300/EnIcvO21hxiNpoI-zO6MDjLmzwPbq8Z4JPo2OKoVUjU.png", 1, "Bats", 0, 1.2f, 4, 3, 1, 3 },
                    { 51, 1, true, 216, "He drifts invisibly through the Arena until he's startled by an enemy... then he attacks! Then he's invisible again! Zzzz.", 3, 1000, 1.8f, "https://api-assets.clashroyale.com/cards/300/3En2cz0ISQAaMTHY3hj3rTveFN2kJYq-H4VxvdJNvCM.png", 9, "Royal Ghost", 3, 1.2f, 3, 0, 0, 3 },
                    { 52, 1, false, 220, "Together they charge through the Arena; snaring enemies, knocking down towers... and chewing grass!?", 5, 1461, 1.8f, "https://api-assets.clashroyale.com/cards/300/QaJyerT7f7oMyZ3Fv1glKymtLSvx7YUXisAulxl7zRI.png", 9, "Ram Rider", 3, 0.8f, 2, 2, 0, 3 },
                    { 53, 3, false, 45, "Spawns a pack of miniature Zap machines. Who controls them...? Only the Master Builder knows.", 4, 250, 2.1f, "https://api-assets.clashroyale.com/cards/300/QZfHRpLRmutZbCr5fpLnTpIp89vLI6NrAwzGZ8tHEc4.png", 3, "Zappies", 1, 4.5f, 2, 3, 0, 3 },
                    { 54, 3, false, 52, "Spawns a mischievous trio of Rascals! The boy takes the lead, while the girls pelt enemies from behind... with slingshots full of Double Trouble Gum!", 5, 758, 1.5f, "https://api-assets.clashroyale.com/cards/300/KV48DfwVHKx9XCjzBdk3daT_Eb52Me4VgjVO7WctRc4.png", 1, "Rascals", 0, 0.8f, 2, 3, 0, 3 },
                    { 55, 1, false, 133, "A Cannon on wheels?! Bet they won't see that coming! Once you break its shield, it becomes a Cannon not on wheels.", 5, 513, 1f, "https://api-assets.clashroyale.com/cards/300/aqwxRz8HXzqlMCO4WMXNA1txynjXTsLinknqsgZLbok.png", 6, "Cannon Cart", 2, 5.5f, 2, 0, 0, 3 },
                    { 56, 1, true, 222, "He lands with the force of 1,000 mustaches, then jumps from one foe to the next dealing huge area damage. Stand aside!", 7, 3300, 1.7f, "https://api-assets.clashroyale.com/cards/300/O2NycChSNhn_UK9nqBXUhhC_lILkiANzPuJjtjoz0CE.png", 9, "Mega Knight", 3, 1.2f, 2, 0, 0, 3 },
                    { 57, 1, true, 52, "It's a Skeleton party in the sky, until all the balloons pop... then it's a Skeleton party on the ground!", 3, 208, 1f, "https://api-assets.clashroyale.com/cards/300/vCB4DWCcrGbTkarjcOiVz4aNDx6GWLm0yUepg9E1MGo.png", 1, "Skeleton Barrel", 0, 0.35f, 3, 2, 1, 3 },
                    { 58, 1, false, 81, "The Master Builder has sent his first contraption to the Arena! It's a fast and fun flying machine, but fragile!", 4, 290, 1.1f, "https://api-assets.clashroyale.com/cards/300/hzKNE3QwFcrSrDDRuVW3QY_OnrDPijSiIp-PsWgFevE.png", 3, "Flying Machine", 1, 6f, 3, 3, 1, 3 },
                    { 59, 2, true, 245, "A daring duo of dangerous dive bombers. Nothing warms a Wall Breaker's cold and undead heart like blowing up buildings.", 2, 207, 1f, "https://api-assets.clashroyale.com/cards/300/hzKNE3QwFcrSrDDRuVW3QY_OnrDPijSiIp-PsWgFevE.png", 6, "Wall Breakers", 2, 0.5f, 4, 2, 0, 3 },
                    { 60, 4, false, 35, "The King’s personal pets are loose! They love to chomp on apples and towers alike - who let the hogs out?!", 5, 395, 1.2f, "https://api-assets.clashroyale.com/cards/300/ASSQJG_MoVq9e81HZzo4bynMnyLNpNJMfSLb3hqydOw.png", 3, "Royal Hogs", 1, 0.7f, 4, 2, 0, 3 },
                    { 61, 1, false, 110, "This jolly green Goblin Giant stomps towards enemy buildings. He carries two Spear Goblins everywhere he goes. It's a weird but functional arrangement.", 6, 2085, 1.5f, "https://api-assets.clashroyale.com/cards/300/SoW16cY3jXBwaTDvb39DkqiVsoFVaDWbzf5QBYphJrY.png", 6, "Goblin Giant", 2, 1.2f, 2, 2, 0, 3 },
                    { 62, 1, false, 160, "His Ranged Attack can pull enemies towards him, and pull himself to enemy buildings. He's also mastered the ancient art of 'Fish Slapping'.", 3, 720, 1.3f, "https://api-assets.clashroyale.com/cards/300/U2KZ3g0wyufcuA5P2Xrn3Z3lr1WiJmc5S0IWOZHgizQ.png", 9, "Fisherman", 3, 1.2f, 2, 0, 0, 3 },
                    { 63, 1, true, 111, "Not quite a Wizard, nor an Archer - he shoots a magic arrow that passes through and damages all enemies in its path. It's not a trick, it's magic!", 4, 440, 1.1f, "https://api-assets.clashroyale.com/cards/300/Avli3W7BxU9HQ2SoLiXnBgGx25FoNXUSFm7OcAk68ek.png", 9, "Magic Archer", 3, 7f, 2, 3, 0, 3 },
                    { 64, 1, true, 360, "Spits out bolts of electricity hitting up to three targets. Suffers from middle child syndrome to boot.", 5, 594, 2.1f, "https://api-assets.clashroyale.com/cards/300/tN9h6lnMNPCNsx0LMFmvpHgznbDZ1fBRkx-C7UfNmfY.png", 6, "Electro Dragon", 2, 3.5f, 2, 3, 1, 3 },
                    { 65, 1, true, 125, "Shoots a firework that explodes on impact, damaging the target and showering anything behind it with sparks. This is what happens when Archers get bored!", 3, 119, 3f, "https://api-assets.clashroyale.com/cards/300/c1rL3LO1U2D9-TkeFfAC18gP3AO8ztSwrcHMZplwL2Q.png", 1, "Firecracker", 0, 6f, 3, 3, 0, 3 },
                    { 66, 1, false, 40, "Walk softly... and carry a big drill! This Champion deals increasing Damage to his target and can switch lanes to escape combat or change attack plans. This makes him not only the mightiest, but also the sneakiest Miner in the Arena.", 4, 2250, 0.4f, "https://api-assets.clashroyale.com/cards/300/Cd9R56yraxTvJiD8xJ2qT2OdsHyh94FqOAarXpbyelo.png", 11, "Mighty Miner", 4, 1.6f, 2, 0, 0, 3 },
                    { 67, 1, false, 120, "Splits into two Elixir Golemites when destroyed, which split into two sentient Blobs when defeated. Each part of the Elixir Golem gives your opponent some Elixir when destroyed!", 3, 740, 1.1f, "https://api-assets.clashroyale.com/cards/300/puhMsZjCIqy21HW3hYxjrk_xt8NIPyFqjRy-BeLKZwo.png", 3, "Elixir Golem", 1, 0.8f, 1, 2, 0, 3 },
                    { 68, 1, false, 70, "With each attack, she unleashes a powerful healing aura that restores Hitpoints to herself and friendly Troops. When she isn't attacking, she passively heals herself!", 4, 810, 1.5f, "https://api-assets.clashroyale.com/cards/300/KdwXcoigS2Kg-cgA7BJJIANbUJG6SNgjetRQ-MegZ08.png", 3, "Battle Healer", 1, 1.6f, 2, 0, 0, 3 },
                    { 69, 1, true, 205, "The King of the undead himself. He sometimes feels lonely (could be due to his non flattering features) and will summon friends to join him in the battle even after death. Tough guys have feelings too!", 4, 2300, 1.6f, "https://api-assets.clashroyale.com/cards/300/dCd69_wN9f8DxwuqOGtR4QgWhHIPIaTNxZ1e23RzAAc.png", 11, "Skeleton King", 4, 1.2f, 2, 0, 0, 3 },
                    { 70, 1, false, 225, "She is fast, deadly and hard to catch. Beware of her crossbow bolts and try not to blink - you might miss her!", 5, 1000, 1.2f, "https://api-assets.clashroyale.com/cards/300/p7OQmOAFTery7zCzlpDdm-LOD1kINTm42AwIHchZfWk.png", 11, "Archer Queen", 4, 5f, 2, 3, 0, 3 },
                    { 71, 1, false, 160, "A warrior with luxurious hair and outstanding flexibility. Demonstrates his aerobics skills on demand.", 4, 1800, 0.9f, "https://api-assets.clashroyale.com/cards/300/WJd207D0O1sN-l1FTb8P9KhYL2oF5jY26vRUfTUW3FQ.png", 11, "Golden Knight", 4, 1.2f, 2, 0, 0, 3 },
                    { 72, 1, false, 140, "Monk has spent many isolated years perfecting a new style of combat. He fires off a 3-hit combo, with the last blow dealing extra Damage and pushing enemies back!", 5, 2000, 0.8f, "https://api-assets.clashroyale.com/cards/300/2onG4t4-CxqwFVZAn6zpWxFz3_mG2ksSj4Q7zldo1SM.png", 11, "Monk", 4, 1.2f, 2, 0, 0, 3 },
                    { 73, 2, true, 63, "This pair of skeletal scorchers deal Area Damage and fly above the Arena. They also play a mean rib cage xylophone duet.", 4, 220, 1.9f, "https://api-assets.clashroyale.com/cards/300/qPOtg9uONh47_NLxGhhFc_ww9PlZ6z3Ry507q1NZUXs.png", 1, "Skeleton Dragons", 0, 3.5f, 3, 3, 1, 3 },
                    { 74, 1, false, 110, "Places a curse on enemy troops with each attack. When a cursed troop is destroyed, it turns into a building-targeting Hog that fights alongside the Mother Witch. She also bakes great cookies.", 4, 440, 1f, "https://api-assets.clashroyale.com/cards/300/fO-Xah8XZkYKaSK9SCp3wnzwxtvIhun9NVY-zzte1Ng.png", 9, "Mother Witch", 3, 5.5f, 2, 3, 0, 3 },
                    { 75, 1, false, 39, "Jumps on enemies, dealing Area damage and stunning up to 9 enemy Troops. Locked in an eternal battle with Knight for the best mustache", 1, 90, 1f, "https://api-assets.clashroyale.com/cards/300/WKd4-IAFsgPpMo7dDi9sujmYjRhOMEWiE07OUJpvD9g.png", 1, "Electro Spirit", 0, 2.5f, 4, 3, 0, 3 },
                    { 76, 1, false, 102, "He channels electricity through his Zap Pack, a unique device that stuns and damages any troop attacking him within its range. Don't tell him that his finger guns aren't real! He'll zap you.", 7, 2410, 2.1f, "https://api-assets.clashroyale.com/cards/300/_uChZkNHAMq6tPb3v6A49xinOe3CnhjstOhG6OZbPYc.png", 6, "Electro Giant", 2, 1.2f, 1, 2, 0, 3 },
                    { 77, 1, false, 180, "This mystical creature will be reborn as an egg when destroyed. If it hatches, it returns to the fight! What an egg-cellent ability. Being born again is tiring, so a hatched Phoenix will have slightly less Hitpoints and Damage (80% of its total).", 4, 870, 1f, "https://api-assets.clashroyale.com/cards/300/i0RoY1fs6ay7VAxyFEfZGIPnD002nAKcne9FtJsWBHM.png", 9, "Phoenix", 3, 1.6f, 2, 3, 1, 3 },
                    { 78, 1, true, 52, "A mischevious Spirit that leaps at enemies, dealing Damage and leaving behind a powerful healing effect that restores Hitpoints to friendly Troops!", 1, 109, 1f, "https://api-assets.clashroyale.com/cards/300/GITl06sa2nGRLPvboyXbGEv5E3I-wAwn1Eqa5esggbc.png", 3, "Heal Spirit", 1, 2.5f, 4, 3, 0, 3 }
                });

            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "Id", "AreaDamage", "Damage", "Description", "Elixir", "ImageUrl", "InitialLevel", "LifeTime", "Name", "Quality", "Radius", "Target", "TowerDamage", "Type" },
                values: new object[,]
                {
                    { 79, true, 325, "Annnnnd... Fireball. Incinerates a small area, dealing high damage. Reduced damage to Crown Towers.", 4, "https://api-assets.clashroyale.com/cards/300/lZD9MILQv7O-P3XBr_xOLS5idwuz3_7Ws9G60U36yhc.png", 3, 0, "FireBall", 1, 2.5f, 3, 97, 1 },
                    { 80, true, 144, "Arrows pepper a large area, damaging all enemies hit. Reduced damage to Crown Towers.", 4, "https://api-assets.clashroyale.com/cards/300/Flsoci-Y6y8ZFVi5uRFTmgkPnCmMyMVrU7YmmuPvSBo.png", 1, 0, "Arrows", 0, 4f, 3, 42, 1 },
                    { 81, true, 120, "Increases troop movement and attack speed. Buildings attack faster and summon troops quicker, too. Chaaaarge!", 2, "https://api-assets.clashroyale.com/cards/300/bGP21OOmcpHMJ5ZA79bHVV2D-NzPtDkvBskCNJb7pg0.png", 6, 6, "Rage", 2, 3f, 3, 36, 1 },
                    { 82, true, 700, "Deals high damage to a small area. Looks really awesome doing it. Reduced damage to Crown Towers.", 6, "https://api-assets.clashroyale.com/cards/300/Ie07nQNK9CjhKOa4-arFAewi4EroqaA-86Xo7r5tx94.png", 3, 0, "Rocket", 1, 2f, 3, 175, 1 },
                    { 83, false, 0, "Spawns three Goblins anywhere in the Arena. It's going to be a thrilling ride, boys!", 3, "https://api-assets.clashroyale.com/cards/300/CoZdp5PpsTH858l212lAMeJxVJ0zxv9V-f5xC8Bvj5g.png", 6, 0, "Goblin Barrel", 2, 1.5f, 4, 0, 1 },
                    { 84, true, 72, "Freezes and damages enemy troops and buildings, making them unable to move or attack. Everybody chill. Reduced damage to Crown Towers.", 4, "https://api-assets.clashroyale.com/cards/300/I1M20_Zs_p_BS1NaNIVQjuMJkYI_1-ePtwYZahn0JXQ.png", 6, 4, "Freeze", 2, 3f, 3, 21, 1 },
                    { 85, false, 0, "Mirrors your last card played for +1 Elixir. Does not appear in your starting hand.", 0, "https://api-assets.clashroyale.com/cards/300/wC6Cm9rKLEOk72zTsukVwxewKIoO4ZcMJun54zCPWvA.png", 6, 0, "Mirror", 2, 0f, 4, 0, 1 },
                    { 86, false, 660, "Bolts of lightning damage and stun up to three enemy troops or buildings with the most hitpoints in the target area. Reduced damage to Crown Towers.", 6, "https://api-assets.clashroyale.com/cards/300/fpnESbYqe5GyZmaVVYe-SEu7tE0Kxh_HZyVigzvLjks.png", 6, 2, "Lightning", 2, 3.5f, 3, 198, 1 },
                    { 87, true, 75, "Zaps enemies, briefly stunning them and dealing damage inside a small radius. Reduced damage to Crown Towers.", 2, "https://api-assets.clashroyale.com/cards/300/7dxh2-yCBy1x44GrBaL29vjqnEEeJXHEAlsi5g6D1eY.png", 1, 0, "Zap", 0, 2.5f, 3, 22, 1 },
                    { 88, true, 57, "Covers the area in a deadly toxin, damaging enemy troops and buildings over time. Yet somehow leaves the grass green and healthy. Go figure! Reduced damage to Crown Towers.", 2, "https://api-assets.clashroyale.com/cards/300/98HDkG2189yOULcVG9jz2QbJKtfuhH21DIrIjkOjxI8.png", 6, 8, "Poison", 2, 3.5f, 3, 17, 1 },
                    { 89, false, 0, "Surprise! It's a party. A Skeleton party, anywhere in the Arena. Yay!", 5, "https://api-assets.clashroyale.com/cards/300/Icp8BIyyfBTj1ncCJS7mb82SY7TPV-MAE-J2L2R48DI.png", 9, 10, "Graveyard", 3, 4f, 4, 0, 1 },
                    { 90, true, 240, "A spilt bottle of Rage turned an innocent tree trunk into \"The Log\". Now, it seeks revenge by crushing anything in its path! Reduced damage to Crown Towers.", 2, "https://api-assets.clashroyale.com/cards/300/_iDwuDLexHPFZ_x4_a0eP-rxCS6vwWgTs6DLauwwoaY.png", 9, 2, "The Log", 3, 3.9f, 0, 48, 1 },
                    { 91, true, 106, "Drags enemy troops to its center while dealing damage over time, just like a magnet. A big, swirling, Tornado-y magnet.", 3, "https://api-assets.clashroyale.com/cards/300/QJB-QK1QJHdw4hjpAwVSyZBozc2ZWAR9pQ-SMUyKaT0.png", 6, 1, "Tornado", 2, 5.5f, 3, 36, 1 },
                    { 92, false, 0, "Duplicates all friendly troops in the target area. Cloned troops are fragile, but pack the same punch as the original! Doesn't affect buildings.", 3, "https://api-assets.clashroyale.com/cards/300/mHVCet-1TkwWq-pxVIU2ZWY9_2z7Z7wtP25ArEUsP_g.png", 6, 0, "Clone", 2, 3f, 3, 0, 1 },
                    { 93, true, 39, "Deals Damage per second to Troops and Crown Towers. Deals huge Building Damage! Does not affect flying units (it is an EARTHquake, after all).", 3, "https://api-assets.clashroyale.com/cards/300/XeQXcrUu59C52DslyZVwCnbi4yamID-WxfVZLShgZmE.png", 3, 3, "Earthquake", 1, 3.5f, 0, 25, 1 },
                    { 94, true, 151, "It rolls over and damages anything in its path, then breaks open and out pops a Barbarian! How did he get inside?!", 2, "https://api-assets.clashroyale.com/cards/300/Gb0G1yNy0i5cIGUHin8uoFWxqntNtRPhY_jeMXg7HnA.png", 6, 1, "Barbarian Barrel", 2, 2.6f, 0, 0, 1 },
                    { 95, true, 75, "It’s HUGE! Once it began rolling down Frozen Peak, there was no stopping it. Enemies hit are knocked back and slowed down. Reduced damage to Crown Towers.", 2, "https://api-assets.clashroyale.com/cards/300/7MaJLa6hK9WN2_VIshuh5DIDfGwm0wEv98gXtAxLDPs.png", 1, 0, "Giant Snowball", 0, 2.5f, 3, 22, 1 },
                    { 96, true, 75, "No need to sign for this package! Dropped from the sky, it deals Area Damage to enemy Troops before delivering a Royal Recruit. The empty box is also handy for espionage.", 3, "https://api-assets.clashroyale.com/cards/300/7MaJLa6hK9WN2_VIshuh5DIDfGwm0wEv98gXtAxLDPs.png", 1, 0, "Royal Delivery", 0, 3f, 3, 0, 1 }
                });

            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "Id", "AreaDamage", "Damage", "Description", "Elixir", "HitPoints", "HitSpeed", "ImageUrl", "InitialLevel", "LifeTime", "Name", "Quality", "Radius", "Range", "Target", "Type" },
                values: new object[,]
                {
                    { 97, false, 83, "Defensive building. Shoots cannonballs with deadly effect, but cannot target flying troops.", 3, 322, 0.9f, "https://api-assets.clashroyale.com/cards/300/nZK1y-beLxO5vnlyUhK6-2zH2NzXJwqykcosqQ1cmZ8.png", 1, 30, "Cannon", 0, 3f, 5.5f, 0, 2 },
                    { 98, false, 0, "Building that spawns Spear Goblins. Don't look inside... You don't want to see how they're made.", 5, 400, 0f, "https://api-assets.clashroyale.com/cards/300/l8ZdzzNLcwB4u7ihGgxNFQOjCT_njFuAhZr7D6PRF7E.png", 3, 29, "Goblin Hut", 1, 3f, 0f, 4, 2 },
                    { 99, true, 104, "Defensive building with a long range. Shoots big boulders that deal area damage, but cannot hit targets that get very close!", 4, 535, 5f, "https://api-assets.clashroyale.com/cards/300/lPOSw6H7YOHq2miSCrf7ZDL3ANjhJdPPDYOTujdNrVE.png", 1, 30, "Mortar", 0, 2f, 11.5f, 0, 2 },
                    { 100, false, 20, "Defensive building, roasts targets for damage that increases over time. Burns through even the biggest and toughest enemies!", 5, 825, 0.4f, "https://api-assets.clashroyale.com/cards/300/GSHY_wrooMMLET6bG_WJB8redtwx66c4i80ipi4gYOM.png", 3, 30, "Inferno Tower", 1, 3f, 6f, 3, 2 },
                    { 101, true, 105, "Defensive building that houses a Bomber. Deals area damage to anything dumb enough to stand near it.", 4, 640, 1.6f, "https://api-assets.clashroyale.com/cards/300/rirYRyHPc97emRjoH-c1O8uZCBzPVnToaGuNGusF3TQ.png", 3, 30, "Bomb Tower", 1, 3f, 6f, 0, 2 },
                    { 102, false, 0, "Building that periodically spawns Barbarians to fight the enemy. Time to make the Barbarians!", 6, 550, 0f, "https://api-assets.clashroyale.com/cards/300/ho0nOG2y3Ch86elHHcocQs8Fv_QNe0cFJ2CijsxABZA.png", 3, 30, "Barbarian Hut", 1, 3f, 0f, 4, 2 },
                    { 103, false, 90, "Defensive building. Whenever it's not zapping the enemy, the power of Electrickery is best kept grounded.", 4, 450, 1.1f, "https://api-assets.clashroyale.com/cards/300/OiwnGrxFMNiHetYEerE-UZt0L_uYNzFY7qV_CA_OxR4.png", 1, 30, "Tesla", 0, 2f, 5.5f, 3, 2 },
                    { 104, false, 0, "You gotta spend Elixir to make Elixir! This building makes 8 Elixir over its Lifetime. Does not appear in your starting hand.", 6, 505, 0f, "https://api-assets.clashroyale.com/cards/300/BGLo3Grsp81c72EpxLLk-Sofk3VY56zahnUNOv3JcT0.png", 3, 65, "Elixir Collector", 1, 3f, 0f, 4, 2 },
                    { 105, false, 26, "Nice tower you got there. Would be a shame if this X-Bow whittled it down from this side of the Arena...", 6, 1000, 0.3f, "https://api-assets.clashroyale.com/cards/300/zVQ9Hme1hlj9Dc6e1ORl9xWwglcSrP7ejow5mAhLUJc.png", 6, 30, "X-Bow", 2, 3f, 11.5f, 0, 2 },
                    { 106, false, 0, "Building that periodically spawns Skeletons to fight the enemy... and when destroyed, spawns 4 more Skeletons! Creepy.", 3, 250, 0f, "https://api-assets.clashroyale.com/cards/300/LjSfSbwQfkZuRJY4pVxKspZ-a0iM5KAhU8w-a_N5Z7Y.png", 3, 30, "Tombstone", 1, 3f, 0f, 4, 2 },
                    { 107, false, 0, "The Furnace spawns one Fire Spirit at a time. It also makes great brick-oven pancakes.", 4, 400, 0f, "https://api-assets.clashroyale.com/cards/300/iqbDiG7yYRIzvCPXdt9zPb3IvMt7F7Gi4wIPnh2x4aI.png", 3, 28, "Furnace", 1, 3f, 0f, 4, 2 },
                    { 108, false, 0, "When the Goblin Cage is destroyed, a Goblin Brawler is unleashed into the Arena! Goblin Brawler always skips leg day.", 4, 350, 0f, "https://api-assets.clashroyale.com/cards/300/vD24bBgK4rSq7wx5QEbuqChtPMRFviL_ep76GwQw1yA.png", 3, 20, "Goblin Cage", 1, 3f, 0f, 4, 2 },
                    { 109, false, 0, "Building capable of burrowing underground and appearing anywhere in the Arena. Spawns Goblins one at a time until destroyed.", 4, 900, 0f, "https://api-assets.clashroyale.com/cards/300/eN2TKUYbih-26yBi0xy5LVFOA0zDftgDqxxnVfdIg1o.png", 6, 9, "Goblin Drill", 2, 2f, 0f, 4, 2 }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("aa8f19cf-9a70-4b70-ae92-e67e42120122"), "User" },
                    { new Guid("b225e79f-d3c1-49fe-9dce-06ae22cbfeaf"), "SuperAdmin" },
                    { new Guid("ffd134e8-96ca-40e9-9e69-84b4e18c4c0a"), "Admin" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "PasswordHash", "PlayerId", "RoleId", "UserName" },
                values: new object[] { new Guid("fdc931b1-c3e8-49fd-b201-dd2b6f02bc65"), "AQAAAAIAAYagAAAAEJ57UyoO2lh9/HwCDUr/CiUXek0mgnMxdWSGBa2HpU+i97XD4pZ8ezQWjtd3BJVLeQ==", null, null, "superadmin" });

            migrationBuilder.CreateIndex(
                name: "IX_Battles_LoserId",
                table: "Battles",
                column: "LoserId");

            migrationBuilder.CreateIndex(
                name: "IX_Battles_WinnerId_LoserId_Date",
                table: "Battles",
                columns: new[] { "WinnerId", "LoserId", "Date" },
                unique: true,
                filter: "[WinnerId] IS NOT NULL AND [LoserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ClanPlayers_ClanId",
                table: "ClanPlayers",
                column: "ClanId");

            migrationBuilder.CreateIndex(
                name: "IX_ClanWars_WarId",
                table: "ClanWars",
                column: "WarId");

            migrationBuilder.CreateIndex(
                name: "IX_Collection_CardId",
                table: "Collection",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_Donations_CardId",
                table: "Donations",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_Donations_ClanId",
                table: "Donations",
                column: "ClanId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerChallenges_ChallengeId",
                table: "PlayerChallenges",
                column: "ChallengeId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_FavoriteCardId",
                table: "Players",
                column: "FavoriteCardId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_Name",
                table: "Roles",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_PlayerId",
                table: "Users",
                column: "PlayerId",
                unique: true,
                filter: "[PlayerId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Battles");

            migrationBuilder.DropTable(
                name: "ClanPlayers");

            migrationBuilder.DropTable(
                name: "ClanWars");

            migrationBuilder.DropTable(
                name: "Collection");

            migrationBuilder.DropTable(
                name: "Donations");

            migrationBuilder.DropTable(
                name: "PlayerChallenges");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Wars");

            migrationBuilder.DropTable(
                name: "Clans");

            migrationBuilder.DropTable(
                name: "Challenges");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Cards");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ClashRoyaleClanWarsAPI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeNameTableChallengePlayers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayerChallenges");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "122770ca-a0c1-46ff-b849-ac199ea5f7c1");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "e5096c80-e8d4-4069-982c-3ac0a3e83047");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e606454d-dfc6-4134-8a0b-df26290f3b7e", "21863356-0820-41ec-8028-623e9ba30baa" });

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "e606454d-dfc6-4134-8a0b-df26290f3b7e");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "21863356-0820-41ec-8028-623e9ba30baa");

            migrationBuilder.CreateTable(
                name: "ChallengePlayers",
                columns: table => new
                {
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    ChallengeId = table.Column<int>(type: "int", nullable: false),
                    PrizeAmount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChallengePlayers", x => new { x.PlayerId, x.ChallengeId });
                    table.ForeignKey(
                        name: "FK_ChallengePlayers_Challenges_ChallengeId",
                        column: x => x.ChallengeId,
                        principalTable: "Challenges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChallengePlayers_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "27bdf5ef-cbfa-4219-8802-ef38c0e722e5", "0ce6a689-eb1e-404b-b87d-d06e66111449", "SuperAdmin", "SUPERADMIN" },
                    { "6149c78a-91b3-4194-babf-a891f770504c", "76ea9e78-ec9c-4f21-88aa-919e6574d8f5", "Admin", "ADMIN" },
                    { "80db3ff6-0ac8-415b-a431-57701c3287b2", "efcbe062-5d5f-4f55-9353-086c5c159e92", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "43ffa0c4-ea2c-4b23-a191-e981c81ae341", 0, "9e5e77c3-27b0-4ded-84a0-57f23bba4629", null, false, false, null, null, "SUPERADMIN", "AQAAAAIAAYagAAAAEFyCqs1xE9BbsDnQck0wLNgl4ob05zLkywJ2jNeFBu4NmzFQz7QlAjdgUmI8PaIJ/w==", null, false, "fcc79220-868d-4582-bde2-5740ca758a53", false, "superadmin" });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "27bdf5ef-cbfa-4219-8802-ef38c0e722e5", "43ffa0c4-ea2c-4b23-a191-e981c81ae341" });

            migrationBuilder.CreateIndex(
                name: "IX_ChallengePlayers_ChallengeId",
                table: "ChallengePlayers",
                column: "ChallengeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChallengePlayers");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "6149c78a-91b3-4194-babf-a891f770504c");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "80db3ff6-0ac8-415b-a431-57701c3287b2");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "27bdf5ef-cbfa-4219-8802-ef38c0e722e5", "43ffa0c4-ea2c-4b23-a191-e981c81ae341" });

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "27bdf5ef-cbfa-4219-8802-ef38c0e722e5");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "43ffa0c4-ea2c-4b23-a191-e981c81ae341");

            migrationBuilder.CreateTable(
                name: "PlayerChallenges",
                columns: table => new
                {
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    ChallengeId = table.Column<int>(type: "int", nullable: false),
                    PrizeAmount = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "122770ca-a0c1-46ff-b849-ac199ea5f7c1", "dee33159-bb14-4512-ba79-71ec882545fe", "User", "USER" },
                    { "e5096c80-e8d4-4069-982c-3ac0a3e83047", "c438c423-992e-48b5-bb75-fceb2ab05737", "Admin", "ADMIN" },
                    { "e606454d-dfc6-4134-8a0b-df26290f3b7e", "a4f91a73-b0bf-47a3-a07c-6dcb58e98af2", "SuperAdmin", "SUPERADMIN" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "21863356-0820-41ec-8028-623e9ba30baa", 0, "35e22ad7-16d1-43c9-92f3-1e2d73da75ff", null, false, false, null, null, "SUPERADMIN", "AQAAAAIAAYagAAAAEGO9kcxea/II1Gpj/cCHpKYvkF/ze5dfGP0xXjNTZv4YxSwLH/DNrAvsUrP2JKnvkg==", null, false, "a1468969-9cf5-4447-ab01-4a82ccd9853c", false, "superadmin" });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "e606454d-dfc6-4134-8a0b-df26290f3b7e", "21863356-0820-41ec-8028-623e9ba30baa" });

            migrationBuilder.CreateIndex(
                name: "IX_PlayerChallenges_ChallengeId",
                table: "PlayerChallenges",
                column: "ChallengeId");
        }
    }
}

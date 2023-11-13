using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ClashRoyaleClanWarsAPI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeNameTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChallengePlayers_Challenges_ChallengeId",
                table: "ChallengePlayers");

            migrationBuilder.DropForeignKey(
                name: "FK_ChallengePlayers_Players_PlayerId",
                table: "ChallengePlayers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChallengePlayers",
                table: "ChallengePlayers");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "2f56b216-ff3b-43b8-b932-4f25948a2a4c");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "ffcdf181-39e5-4a8e-8e21-102359d5b658");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d4766b0a-6979-4fd9-9a0c-501ae0035821", "dfab79f2-410d-4a6c-9db5-1e61162e51c7" });

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "d4766b0a-6979-4fd9-9a0c-501ae0035821");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "dfab79f2-410d-4a6c-9db5-1e61162e51c7");

            migrationBuilder.RenameTable(
                name: "ChallengePlayers",
                newName: "PlayerChallenges");

            migrationBuilder.RenameIndex(
                name: "IX_ChallengePlayers_ChallengeId",
                table: "PlayerChallenges",
                newName: "IX_PlayerChallenges_ChallengeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlayerChallenges",
                table: "PlayerChallenges",
                columns: new[] { "PlayerId", "ChallengeId" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "61be2ad5-7ee4-4ba9-b694-a2253f472222", "8fa9fc56-d770-4f57-ba51-200199eee700", "User", "USER" },
                    { "ef477d3e-e618-4a1e-83da-0fade6f6c464", "4554daf5-7956-440c-848c-c4ebf9f5a0ba", "Admin", "ADMIN" },
                    { "f817594a-3295-446c-85b5-0b9993983074", "7eb03dba-021e-4247-824e-03673e73f900", "SuperAdmin", "SUPERADMIN" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "72c18631-a3ed-4443-8c7d-52623979f187", 0, "2959101c-cd85-4b99-82ad-6aa26346a15d", null, false, false, null, null, "SUPERADMIN", "AQAAAAIAAYagAAAAEHbUOR7qOvn85SoQ1lBlA4e/V6QlJWS/tl2fN/SnlX+w6OuVr6yAAdL5qRDSInMg9g==", null, false, "c0ad543e-f1ab-45ab-ba94-db00ee5848cd", false, "superadmin" });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "f817594a-3295-446c-85b5-0b9993983074", "72c18631-a3ed-4443-8c7d-52623979f187" });

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerChallenges_Challenges_ChallengeId",
                table: "PlayerChallenges",
                column: "ChallengeId",
                principalTable: "Challenges",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerChallenges_Players_PlayerId",
                table: "PlayerChallenges",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerChallenges_Challenges_ChallengeId",
                table: "PlayerChallenges");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerChallenges_Players_PlayerId",
                table: "PlayerChallenges");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlayerChallenges",
                table: "PlayerChallenges");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "61be2ad5-7ee4-4ba9-b694-a2253f472222");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "ef477d3e-e618-4a1e-83da-0fade6f6c464");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f817594a-3295-446c-85b5-0b9993983074", "72c18631-a3ed-4443-8c7d-52623979f187" });

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "f817594a-3295-446c-85b5-0b9993983074");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "72c18631-a3ed-4443-8c7d-52623979f187");

            migrationBuilder.RenameTable(
                name: "PlayerChallenges",
                newName: "ChallengePlayers");

            migrationBuilder.RenameIndex(
                name: "IX_PlayerChallenges_ChallengeId",
                table: "ChallengePlayers",
                newName: "IX_ChallengePlayers_ChallengeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChallengePlayers",
                table: "ChallengePlayers",
                columns: new[] { "PlayerId", "ChallengeId" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2f56b216-ff3b-43b8-b932-4f25948a2a4c", "63affd36-4d7f-492d-b7d4-916ec7d3214e", "User", "USER" },
                    { "d4766b0a-6979-4fd9-9a0c-501ae0035821", "f72013ab-4273-4704-aa05-e0654eb5b1d2", "SuperAdmin", "SUPERADMIN" },
                    { "ffcdf181-39e5-4a8e-8e21-102359d5b658", "6f18b1c3-84c5-48e0-9e86-3bb66ca04085", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "dfab79f2-410d-4a6c-9db5-1e61162e51c7", 0, "1189dfff-6c33-4d0e-ad29-ea3c6fd7e3aa", null, false, false, null, null, "SUPERADMIN", "AQAAAAIAAYagAAAAEPgyx3EbCr9RHxFoHgwnF2o9QdSAyAnDBP1Vsg9jXlM08gjuCbfPTXcIjMJ/pc7GGQ==", null, false, "cc80e829-0037-498a-b90c-67fbcf77f0a3", false, "superadmin" });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "d4766b0a-6979-4fd9-9a0c-501ae0035821", "dfab79f2-410d-4a6c-9db5-1e61162e51c7" });

            migrationBuilder.AddForeignKey(
                name: "FK_ChallengePlayers_Challenges_ChallengeId",
                table: "ChallengePlayers",
                column: "ChallengeId",
                principalTable: "Challenges",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChallengePlayers_Players_PlayerId",
                table: "ChallengePlayers",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id");
        }
    }
}

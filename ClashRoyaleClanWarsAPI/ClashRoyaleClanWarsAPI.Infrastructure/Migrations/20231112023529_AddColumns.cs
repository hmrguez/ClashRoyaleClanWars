using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ClashRoyaleClanWarsAPI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Donations",
                table: "Donations");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "be5d76f3-3ba2-419c-869e-f91b1b6c3199");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "dde9fbf0-02a4-4263-88a0-e4dac5493f92");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1ae444f0-3d96-4fb6-bdfb-285e7c6da675", "f262fa7c-e34f-4f68-a4fa-bc820e0d09f8" });

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "1ae444f0-3d96-4fb6-bdfb-285e7c6da675");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "f262fa7c-e34f-4f68-a4fa-bc820e0d09f8");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Donations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsCompleted",
                table: "ChallengePlayers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Donations",
                table: "Donations",
                columns: new[] { "PlayerId", "ClanId", "CardId", "Date" });

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Donations",
                table: "Donations");

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

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Donations");

            migrationBuilder.DropColumn(
                name: "IsCompleted",
                table: "ChallengePlayers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Donations",
                table: "Donations",
                columns: new[] { "PlayerId", "ClanId", "CardId" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1ae444f0-3d96-4fb6-bdfb-285e7c6da675", "422557c5-bbce-4b1a-8f0e-dfdafa27b3a3", "SuperAdmin", "SUPERADMIN" },
                    { "be5d76f3-3ba2-419c-869e-f91b1b6c3199", "4cdb1b84-c5f2-4f00-bf90-1ea7fcc6efea", "Admin", "ADMIN" },
                    { "dde9fbf0-02a4-4263-88a0-e4dac5493f92", "74a31b41-710e-4c6b-8839-27a1e08007cf", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "f262fa7c-e34f-4f68-a4fa-bc820e0d09f8", 0, "ec3dd60f-155b-4954-a314-6c90debabfd1", null, false, false, null, null, "SUPERADMIN", "AQAAAAIAAYagAAAAEInUOJIOPMp7tB7MPMonpF6RihV6AHHZoWBXBiLSf0ViszNkcAunu/NEbyB8zNq4pA==", null, false, "d0b79358-e540-4789-a395-6cb206db7306", false, "superadmin" });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1ae444f0-3d96-4fb6-bdfb-285e7c6da675", "f262fa7c-e34f-4f68-a4fa-bc820e0d09f8" });
        }
    }
}

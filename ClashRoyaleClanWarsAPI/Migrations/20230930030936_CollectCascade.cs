using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ClashRoyaleClanWarsAPI.Migrations
{
    /// <inheritdoc />
    public partial class CollectCascade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Collection_Players_PlayerId",
                table: "Collection");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "1db6b75a-800e-4367-93cd-9eff3864d742");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "940f2923-a90b-4e9c-b01a-7db02da35646");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "356c6138-7e50-49e3-9cf6-5363747b1fb5", "9c9300a6-7005-46c6-8259-dbc18542328d" });

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "356c6138-7e50-49e3-9cf6-5363747b1fb5");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "9c9300a6-7005-46c6-8259-dbc18542328d");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5d3f2933-a621-41ec-b84b-6eedc0e78f29", "3106cb33-8130-46b3-93c2-ed88e9c08bbd", "User", "USER" },
                    { "752a6e39-4e64-45da-9d8e-d8c74984cccd", "27f4749d-1fff-4dcf-b2fe-54612e3a8fbd", "SuperAdmin", "SUPERADMIN" },
                    { "8e29a83a-d2ca-4cdb-9954-fa21cef37945", "6bda4c08-8853-47e1-873c-457cf129d3ec", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "5104f232-fbc9-4907-86af-7280f04352aa", 0, "4175bd83-b8ad-4aaa-a1d3-82c8d280aa0f", null, false, false, null, null, "SUPERADMIN", "AQAAAAIAAYagAAAAEO9IJwtJfmCHAnIRNekWYE2bh40tPIdlkFj21LPbtvBtR4yoAiSOQOYOzrYzGBu7NA==", null, false, "59fa99c1-3864-4810-a798-9267c1da1f68", false, "superadmin" });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "752a6e39-4e64-45da-9d8e-d8c74984cccd", "5104f232-fbc9-4907-86af-7280f04352aa" });

            migrationBuilder.AddForeignKey(
                name: "FK_Collection_Players_PlayerId",
                table: "Collection",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Collection_Players_PlayerId",
                table: "Collection");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "5d3f2933-a621-41ec-b84b-6eedc0e78f29");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "8e29a83a-d2ca-4cdb-9954-fa21cef37945");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "752a6e39-4e64-45da-9d8e-d8c74984cccd", "5104f232-fbc9-4907-86af-7280f04352aa" });

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "752a6e39-4e64-45da-9d8e-d8c74984cccd");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "5104f232-fbc9-4907-86af-7280f04352aa");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1db6b75a-800e-4367-93cd-9eff3864d742", "2d7bcc22-5662-4935-ac68-75074c59cc42", "User", "USER" },
                    { "356c6138-7e50-49e3-9cf6-5363747b1fb5", "6f6113e8-6142-47b6-8c38-1777aa6bf536", "SuperAdmin", "SUPERADMIN" },
                    { "940f2923-a90b-4e9c-b01a-7db02da35646", "484e1276-c96b-405a-a472-71841e0e7827", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "9c9300a6-7005-46c6-8259-dbc18542328d", 0, "dcc3d6a1-00f2-4362-bcef-c70bf131ecbe", null, false, false, null, null, "SUPERADMIN", "AQAAAAIAAYagAAAAEOxBFvsSlYMGEnSU9kW4N6XKzD72pIHv14A63uFqMuggfreJJ1nTI8lC7qustG+F1g==", null, false, "ffb41fd2-6233-4a59-a905-aa7ae51e777f", false, "superadmin" });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "356c6138-7e50-49e3-9cf6-5363747b1fb5", "9c9300a6-7005-46c6-8259-dbc18542328d" });

            migrationBuilder.AddForeignKey(
                name: "FK_Collection_Players_PlayerId",
                table: "Collection",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id");
        }
    }
}

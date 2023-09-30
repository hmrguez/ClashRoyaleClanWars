using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ClashRoyaleClanWarsAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedRolesAndSuperAdminUser : Migration
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
                keyValue: "8458eba9-21e3-4ce8-9ccc-b45daab363a5");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "ae379cec-017f-4908-9afd-09f34646f1c6");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3358cf8c-b267-4b5a-b8cf-9c9d4e343ad4", "47afa968-1d75-4502-a646-095eac31d3a0" });

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "3358cf8c-b267-4b5a-b8cf-9c9d4e343ad4");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "47afa968-1d75-4502-a646-095eac31d3a0");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "3358cf8c-b267-4b5a-b8cf-9c9d4e343ad4", "fc6f7286-5b70-4828-b3d3-af9bc2f1faa9", "SuperAdmin", "SUPERADMIN" },
                    { "8458eba9-21e3-4ce8-9ccc-b45daab363a5", "a7b49d39-a219-411d-b1ec-4d90b9919ef8", "User", "USER" },
                    { "ae379cec-017f-4908-9afd-09f34646f1c6", "465c0834-e4e3-4254-b6d7-343207733ccd", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "47afa968-1d75-4502-a646-095eac31d3a0", 0, "f2153349-9ceb-46ad-b309-84cd876254ea", null, false, false, null, null, "SUPERADMIN", "AQAAAAIAAYagAAAAEKAWUsr49FRtluhyl2qh5XB58vow6cGahRzoQyIIWTvD07aWM8aY4pm+H+KzSe1T5g==", null, false, "cb88b090-b5cc-40d8-ad96-db7c14f4409e", false, "superadmin" });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "3358cf8c-b267-4b5a-b8cf-9c9d4e343ad4", "47afa968-1d75-4502-a646-095eac31d3a0" });

            migrationBuilder.AddForeignKey(
                name: "FK_Collection_Players_PlayerId",
                table: "Collection",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

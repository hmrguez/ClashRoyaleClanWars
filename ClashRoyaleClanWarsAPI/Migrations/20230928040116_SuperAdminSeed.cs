using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ClashRoyaleClanWarsAPI.Migrations
{
    /// <inheritdoc />
    public partial class SuperAdminSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7d917882-e026-487b-ab77-4bebe3097d74", null, "Admin", "ADMIN" },
                    { "bac786e3-81d3-4620-a377-f825ccd749a8", null, "User", "USER" },
                    { "e400d177-52c8-4b74-b26f-aa5fe6094ae2", null, "SuperAdmin", "SUPERADMIN" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "35e0e461-c7d6-4bba-8353-1ffef7c1ad73", 0, "7e034945-fd53-48a1-8987-d54721ffeec8", null, false, false, null, null, "SUPERADMIN", "AQAAAAIAAYagAAAAEDtSlUcnHwu5RO+QxFMKVSWK8luhKkExbDbxhu+Bo+HCI3qTaY5lAlT1cjzoOLw6BQ==", null, false, "15572521-c439-4754-8473-2f979345f3d2", false, "superadmin" });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "e400d177-52c8-4b74-b26f-aa5fe6094ae2", "35e0e461-c7d6-4bba-8353-1ffef7c1ad73" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "7d917882-e026-487b-ab77-4bebe3097d74");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "bac786e3-81d3-4620-a377-f825ccd749a8");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e400d177-52c8-4b74-b26f-aa5fe6094ae2", "35e0e461-c7d6-4bba-8353-1ffef7c1ad73" });

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "e400d177-52c8-4b74-b26f-aa5fe6094ae2");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "35e0e461-c7d6-4bba-8353-1ffef7c1ad73");
        }
    }
}

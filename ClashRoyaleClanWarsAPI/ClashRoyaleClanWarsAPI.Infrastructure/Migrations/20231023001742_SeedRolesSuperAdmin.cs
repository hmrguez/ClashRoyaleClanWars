using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ClashRoyaleClanWarsAPI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedRolesSuperAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "59759cfd-d920-403a-964b-512b32e0b190", "761ce22b-260a-48a8-89ca-5e6355c7effd", "SuperAdmin", "SUPERADMIN" },
                    { "81faf4d6-1873-4be6-9d0b-34032c961946", "2917cad5-4a43-4517-8817-3de2e1cce2d4", "User", "USER" },
                    { "bda61c6b-857b-4faa-8d91-17b06f0ac464", "d68e8cd3-8057-4669-8256-4fcca45feb28", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "cfd1f264-1e3f-4cc9-afaf-cac289cdaaf9", 0, "6777f960-51a3-4270-a881-163c439e3abb", null, false, false, null, null, "SUPERADMIN", "AQAAAAIAAYagAAAAEE21Xr7ZheyZx0S2YFEpQtP9tyQKE/ACmHf7MhsossDYzX5HWltvqnlJXJmX4elSYw==", null, false, "9cde4f10-366a-43a2-8ecc-84c62fd8636d", false, "superadmin" });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "59759cfd-d920-403a-964b-512b32e0b190", "cfd1f264-1e3f-4cc9-afaf-cac289cdaaf9" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "81faf4d6-1873-4be6-9d0b-34032c961946");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "bda61c6b-857b-4faa-8d91-17b06f0ac464");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "59759cfd-d920-403a-964b-512b32e0b190", "cfd1f264-1e3f-4cc9-afaf-cac289cdaaf9" });

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "59759cfd-d920-403a-964b-512b32e0b190");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "cfd1f264-1e3f-4cc9-afaf-cac289cdaaf9");
        }
    }
}

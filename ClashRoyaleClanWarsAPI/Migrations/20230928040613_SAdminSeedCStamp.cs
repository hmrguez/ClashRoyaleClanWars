using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ClashRoyaleClanWarsAPI.Migrations
{
    /// <inheritdoc />
    public partial class SAdminSeedCStamp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1682e7a1-09ec-418a-97c7-677d8adbba89", "fbf4c076-301a-4cb2-a87f-972f1c177102", "User", "USER" },
                    { "7692d181-5ab9-4517-aaa6-607f10d03d1a", "5e51958a-4162-4810-ac04-f85a5f2cd3ff", "SuperAdmin", "SUPERADMIN" },
                    { "88fdcc4f-e1d6-4c28-808c-fa337748f51f", "e8df1457-9836-4ae1-9709-b47dbc3e2df0", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "5a34ed5c-3642-474e-84c1-cc3b6ceb1efd", 0, "582e0254-13b6-4987-995c-b55e4f5a6d20", null, false, false, null, null, "SUPERADMIN", "AQAAAAIAAYagAAAAEMzcd95lSKsx6Z3ClWZoiS/6kCAbcbn2Cyqa7FlnVHNNyW3UY7/pt7rc48EIGRs9FQ==", null, false, "cb32479c-2d6e-4803-bf6d-98f1a87b6cfc", false, "superadmin" });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "7692d181-5ab9-4517-aaa6-607f10d03d1a", "5a34ed5c-3642-474e-84c1-cc3b6ceb1efd" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "1682e7a1-09ec-418a-97c7-677d8adbba89");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "88fdcc4f-e1d6-4c28-808c-fa337748f51f");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "7692d181-5ab9-4517-aaa6-607f10d03d1a", "5a34ed5c-3642-474e-84c1-cc3b6ceb1efd" });

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "7692d181-5ab9-4517-aaa6-607f10d03d1a");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "5a34ed5c-3642-474e-84c1-cc3b6ceb1efd");

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
    }
}

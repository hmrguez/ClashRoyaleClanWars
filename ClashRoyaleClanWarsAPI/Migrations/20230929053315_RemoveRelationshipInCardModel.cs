using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ClashRoyaleClanWarsAPI.Migrations
{
    /// <inheritdoc />
    public partial class RemoveRelationshipInCardModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "4b09bf94-7d1e-4ffb-b6b2-9c42f545769e", "1e457438-68c8-4cb0-8278-a77f2743550a", "Admin", "ADMIN" },
                    { "a69bf1f3-9dd2-479f-ad5f-77a2039640f2", "4a037a90-bc6f-482f-9de1-c1a223661251", "SuperAdmin", "SUPERADMIN" },
                    { "ca31dbee-5cbc-4f02-9833-e31676116d50", "4c13dc8a-3d91-4238-bbec-4fd27f27d9e0", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b948e02e-b956-4acc-a40a-3db1ce6b12cd", 0, "77186ffc-2131-4f6a-b5e9-84dccd6dfe8f", null, false, false, null, null, "SUPERADMIN", "AQAAAAIAAYagAAAAEGzex/WLdK7HHIzl0d2AEjGm/8bHRplUB1pDfPk6pyzZ1irKlyeM58f4LK7q9B8Tyg==", null, false, "32170bb2-32ee-4179-94f1-06bf285209bb", false, "superadmin" });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "a69bf1f3-9dd2-479f-ad5f-77a2039640f2", "b948e02e-b956-4acc-a40a-3db1ce6b12cd" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "4b09bf94-7d1e-4ffb-b6b2-9c42f545769e");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "ca31dbee-5cbc-4f02-9833-e31676116d50");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a69bf1f3-9dd2-479f-ad5f-77a2039640f2", "b948e02e-b956-4acc-a40a-3db1ce6b12cd" });

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "a69bf1f3-9dd2-479f-ad5f-77a2039640f2");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "b948e02e-b956-4acc-a40a-3db1ce6b12cd");

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
    }
}

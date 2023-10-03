using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ClashRoyaleClanWarsAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeddRolesSuperAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "32d19477-9dbe-4492-aafd-bf4c1bed1d97");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "3ff70144-ac62-444e-ab21-67991b32999b");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1cb6e246-943f-4704-95b3-ad6d77310c4e", "5d75881a-489a-4406-9d19-8f3c9f46efaa" });

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "1cb6e246-943f-4704-95b3-ad6d77310c4e");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "5d75881a-489a-4406-9d19-8f3c9f46efaa");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0add7f67-8df7-4c74-bf21-1a05f44ad0c9", "6c1dc17e-13e9-4a29-aca7-4505e493f1c2", "SuperAdmin", "SUPERADMIN" },
                    { "6b592a98-7029-4bc8-b4c2-34ab85f94c0c", "a1c8abe5-469d-4848-9473-56ba8f63a8a3", "Admin", "ADMIN" },
                    { "ba8e5c4e-b190-4bc9-bf7f-0b800d6d86f1", "bd48ad22-bbf0-44df-ae6c-3a47da163e0f", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1ba5161d-a461-4537-9556-ee9756fde0b6", 0, "539c8261-c4c0-4064-8347-6f36763cef65", null, false, false, null, null, "SUPERADMIN", "AQAAAAIAAYagAAAAEGGFpqnRFZK2TDVt/gJO/QwDVDIsYtfkzvRV5Ecj7VqrEfmJ6gGBOe2/hfwd5qLUqg==", null, false, "5888b277-3674-4f09-bfee-8cd0e40c252e", false, "superadmin" });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "0add7f67-8df7-4c74-bf21-1a05f44ad0c9", "1ba5161d-a461-4537-9556-ee9756fde0b6" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "6b592a98-7029-4bc8-b4c2-34ab85f94c0c");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "ba8e5c4e-b190-4bc9-bf7f-0b800d6d86f1");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0add7f67-8df7-4c74-bf21-1a05f44ad0c9", "1ba5161d-a461-4537-9556-ee9756fde0b6" });

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "0add7f67-8df7-4c74-bf21-1a05f44ad0c9");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "1ba5161d-a461-4537-9556-ee9756fde0b6");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1cb6e246-943f-4704-95b3-ad6d77310c4e", "fdbb32c0-afae-4f27-bb88-4004ccb202d5", "SuperAdmin", "SUPERADMIN" },
                    { "32d19477-9dbe-4492-aafd-bf4c1bed1d97", "822e4c13-fe8e-409b-a85f-6e0c35016371", "Admin", "ADMIN" },
                    { "3ff70144-ac62-444e-ab21-67991b32999b", "bf018996-f6d9-4eb2-8fb8-abcfa6c44ef5", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "5d75881a-489a-4406-9d19-8f3c9f46efaa", 0, "2c6760b0-69d1-48e5-bacb-7674433f1ef7", null, false, false, null, null, "SUPERADMIN", "AQAAAAIAAYagAAAAEKdlONo0Tq3G73T5XQuxJdxgNct4aPxgzKDb++2HBXbTSoSgz7TkIx/8C4p3Yg19dg==", null, false, "7ba97f31-f66a-48a3-b272-d322eec88121", false, "superadmin" });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1cb6e246-943f-4704-95b3-ad6d77310c4e", "5d75881a-489a-4406-9d19-8f3c9f46efaa" });
        }
    }
}

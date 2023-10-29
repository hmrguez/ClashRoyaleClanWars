using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ClashRoyaleClanWarsAPI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "2ab6641e-64a7-4bc5-b9a2-008df817ad65");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "a52bf2f8-b099-4a49-bc47-ac27572ab08a");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "9ac3ae48-7723-485e-8dd1-b1f2a24c4d5b", "517b900e-7db3-4c66-9fb7-07529f63a666" });

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "9ac3ae48-7723-485e-8dd1-b1f2a24c4d5b");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "517b900e-7db3-4c66-9fb7-07529f63a666");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2ab6641e-64a7-4bc5-b9a2-008df817ad65", "a20f0746-5c22-4a08-8f28-ca6c20dedf82", "Admin", "ADMIN" },
                    { "9ac3ae48-7723-485e-8dd1-b1f2a24c4d5b", "f5cf0c19-f37e-4b55-8604-8b986aa60c3e", "SuperAdmin", "SUPERADMIN" },
                    { "a52bf2f8-b099-4a49-bc47-ac27572ab08a", "92ffe4d8-2d79-4c54-bb56-85a80f5a718b", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "517b900e-7db3-4c66-9fb7-07529f63a666", 0, "6663eb1e-ed58-432e-be38-6b4d3b647740", null, false, false, null, null, "SUPERADMIN", "AQAAAAIAAYagAAAAECCzu3FIWFdDjKB70oA62Uhy+1UW/0FpZA2yem4UvIKk6JMTf1/ZxwpQYmepPwLFgA==", null, false, "d5c68ead-c4f9-44b1-9d17-6fecd54e4d3b", false, "superadmin" });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "9ac3ae48-7723-485e-8dd1-b1f2a24c4d5b", "517b900e-7db3-4c66-9fb7-07529f63a666" });
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ClashRoyaleClanWarsAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedingRoles_SuperAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0797ea23-1a73-4c7c-923c-51778e9e0987", "318316bd-69b4-49f4-83e9-7ca1cea97b23", "User", "USER" },
                    { "08dc97e0-723d-415b-8130-24af6d70ffab", "50e9fdc1-a196-4f5f-adbe-baff0b6389f7", "Admin", "ADMIN" },
                    { "49b84848-066f-4ebc-8b88-c1f14237dfcf", "8e894491-090f-4098-b028-48a0e1175f00", "SuperAdmin", "SUPERADMIN" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "735dce2c-2197-437e-b17f-bbfb34df23d0", 0, "e1ba58f9-4f2b-4ff8-a9e9-39b34bec3ea4", null, false, false, null, null, "SUPERADMIN", "AQAAAAIAAYagAAAAEDlmI6YivA3v3Y/cBJEkbvrzvqofh/IqFhppQIsSssx3CdOI9RByuJD/Tmr/d1ocQQ==", null, false, "12b87e06-bdf8-44ea-be87-9319bbb8d43e", false, "superadmin" });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "49b84848-066f-4ebc-8b88-c1f14237dfcf", "735dce2c-2197-437e-b17f-bbfb34df23d0" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "0797ea23-1a73-4c7c-923c-51778e9e0987");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "08dc97e0-723d-415b-8130-24af6d70ffab");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "49b84848-066f-4ebc-8b88-c1f14237dfcf", "735dce2c-2197-437e-b17f-bbfb34df23d0" });

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "49b84848-066f-4ebc-8b88-c1f14237dfcf");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "735dce2c-2197-437e-b17f-bbfb34df23d0");
        }
    }
}

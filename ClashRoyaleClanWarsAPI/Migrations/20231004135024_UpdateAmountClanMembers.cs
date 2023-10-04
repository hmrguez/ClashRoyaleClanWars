using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ClashRoyaleClanWarsAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAmountClanMembers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<int>(
                name: "AmountMembers",
                table: "Clans",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 1);

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "60967d6f-bff8-44ca-8c68-ff2581295e67", "bc892afb-1ee0-4ecf-b01f-8ad2d1ecb97c", "Admin", "ADMIN" },
                    { "8e77c5d7-ecc0-4042-9da1-18b5d6c7b7df", "6cb352ab-7239-4458-9fe7-54e04da71b53", "SuperAdmin", "SUPERADMIN" },
                    { "dcd8ba62-2a0d-44f5-a9ba-0ad5bcd98340", "b4b6f31f-7e11-4780-ac49-73716145194a", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "e9994d69-4921-4835-b42c-81d8f87db4ad", 0, "4f9cbd26-fe0e-461d-be61-5403bd5d4a52", null, false, false, null, null, "SUPERADMIN", "AQAAAAIAAYagAAAAEDIZuPsS76UzwzSP+70KfXluypjp57IHTIFxho22ZBbqOqzhRKgFNZYSb1mQJBrzEw==", null, false, "4649fd73-9422-46ac-8035-3ba994127f0e", false, "superadmin" });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "8e77c5d7-ecc0-4042-9da1-18b5d6c7b7df", "e9994d69-4921-4835-b42c-81d8f87db4ad" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "60967d6f-bff8-44ca-8c68-ff2581295e67");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "dcd8ba62-2a0d-44f5-a9ba-0ad5bcd98340");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "8e77c5d7-ecc0-4042-9da1-18b5d6c7b7df", "e9994d69-4921-4835-b42c-81d8f87db4ad" });

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "8e77c5d7-ecc0-4042-9da1-18b5d6c7b7df");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "e9994d69-4921-4835-b42c-81d8f87db4ad");

            migrationBuilder.AlterColumn<int>(
                name: "AmountMembers",
                table: "Clans",
                type: "int",
                nullable: false,
                defaultValue: 1,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 0);

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
    }
}

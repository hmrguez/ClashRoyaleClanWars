using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ClashRoyaleClanWarsAPI.Migrations
{
    /// <inheritdoc />
    public partial class PlayerClansClanCascade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "816b888b-4e24-47ab-bd69-fd9fdaa11c26");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "e1977a15-60d3-4145-a0e3-11747dc932bf");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "94863767-4e81-42c9-a81a-0d4133719815", "ea2820cf-4219-483b-97b6-4dcc131cb3cf" });

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "94863767-4e81-42c9-a81a-0d4133719815");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "ea2820cf-4219-483b-97b6-4dcc131cb3cf");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "072a4d39-436e-4b60-8b9c-4f58a28e198b", "69a72004-a301-4797-a3f4-5cf6ae9c17e9", "User", "USER" },
                    { "c90c3dca-3b1a-4fe5-96fb-d3585249dbea", "58bf3f72-2f36-46c7-bcf6-adf4fecd1223", "SuperAdmin", "SUPERADMIN" },
                    { "e2fef422-0426-4a3b-a5ea-c214c8c0e009", "cb254aba-0cd8-4b25-86b3-fba273c647a7", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "60ee5684-e1f8-42b5-b5f2-4a944cd98929", 0, "9efa28d8-a9bb-4ea5-b7dc-d064a5d6b3de", null, false, false, null, null, "SUPERADMIN", "AQAAAAIAAYagAAAAENXnSV0XHQuzgM5wvy0BRjkYDr7p0uoDKGIzyLppLtQCRxjHPKbIyYtfUphmd0lSYw==", null, false, "ba78f21c-adca-4491-b77a-fc45f909b2b4", false, "superadmin" });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "c90c3dca-3b1a-4fe5-96fb-d3585249dbea", "60ee5684-e1f8-42b5-b5f2-4a944cd98929" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "072a4d39-436e-4b60-8b9c-4f58a28e198b");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "e2fef422-0426-4a3b-a5ea-c214c8c0e009");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c90c3dca-3b1a-4fe5-96fb-d3585249dbea", "60ee5684-e1f8-42b5-b5f2-4a944cd98929" });

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "c90c3dca-3b1a-4fe5-96fb-d3585249dbea");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "60ee5684-e1f8-42b5-b5f2-4a944cd98929");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "816b888b-4e24-47ab-bd69-fd9fdaa11c26", "de76c547-b405-4f01-8236-db3c01e1d429", "User", "USER" },
                    { "94863767-4e81-42c9-a81a-0d4133719815", "9cda8b1f-1ea2-474f-9ea7-94b62f3cb6e0", "SuperAdmin", "SUPERADMIN" },
                    { "e1977a15-60d3-4145-a0e3-11747dc932bf", "365e5bb1-5f58-400f-9a9e-82f66b2ce8fe", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "ea2820cf-4219-483b-97b6-4dcc131cb3cf", 0, "5eda29fc-6a43-41f5-8fbe-ce706ca2babb", null, false, false, null, null, "SUPERADMIN", "AQAAAAIAAYagAAAAEHPCA7GzoLYGGhIEs/+qj8+O93y/U2gG/ZwQD31hKyXCCsnrOrmIBrTqvhkEZ4F2IA==", null, false, "71dc5432-e063-48cb-904b-0d09eb7f779e", false, "superadmin" });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "94863767-4e81-42c9-a81a-0d4133719815", "ea2820cf-4219-483b-97b6-4dcc131cb3cf" });
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ClashRoyaleClanWarsAPI.Migrations
{
    /// <inheritdoc />
    public partial class PlayerClansCascade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerClans_Players_PlayerId",
                table: "PlayerClans");

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

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerClans_Players_PlayerId",
                table: "PlayerClans",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerClans_Players_PlayerId",
                table: "PlayerClans");

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

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerClans_Players_PlayerId",
                table: "PlayerClans",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id");
        }
    }
}

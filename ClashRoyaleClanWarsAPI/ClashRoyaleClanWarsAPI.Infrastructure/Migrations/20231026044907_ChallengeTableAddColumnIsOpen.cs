using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ClashRoyaleClanWarsAPI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChallengeTableAddColumnIsOpen : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "6149c78a-91b3-4194-babf-a891f770504c");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "80db3ff6-0ac8-415b-a431-57701c3287b2");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "27bdf5ef-cbfa-4219-8802-ef38c0e722e5", "43ffa0c4-ea2c-4b23-a191-e981c81ae341" });

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "27bdf5ef-cbfa-4219-8802-ef38c0e722e5");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "43ffa0c4-ea2c-4b23-a191-e981c81ae341");

            migrationBuilder.AddColumn<bool>(
                name: "IsOpen",
                table: "Challenges",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1ae444f0-3d96-4fb6-bdfb-285e7c6da675", "422557c5-bbce-4b1a-8f0e-dfdafa27b3a3", "SuperAdmin", "SUPERADMIN" },
                    { "be5d76f3-3ba2-419c-869e-f91b1b6c3199", "4cdb1b84-c5f2-4f00-bf90-1ea7fcc6efea", "Admin", "ADMIN" },
                    { "dde9fbf0-02a4-4263-88a0-e4dac5493f92", "74a31b41-710e-4c6b-8839-27a1e08007cf", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "f262fa7c-e34f-4f68-a4fa-bc820e0d09f8", 0, "ec3dd60f-155b-4954-a314-6c90debabfd1", null, false, false, null, null, "SUPERADMIN", "AQAAAAIAAYagAAAAEInUOJIOPMp7tB7MPMonpF6RihV6AHHZoWBXBiLSf0ViszNkcAunu/NEbyB8zNq4pA==", null, false, "d0b79358-e540-4789-a395-6cb206db7306", false, "superadmin" });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1ae444f0-3d96-4fb6-bdfb-285e7c6da675", "f262fa7c-e34f-4f68-a4fa-bc820e0d09f8" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "be5d76f3-3ba2-419c-869e-f91b1b6c3199");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "dde9fbf0-02a4-4263-88a0-e4dac5493f92");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1ae444f0-3d96-4fb6-bdfb-285e7c6da675", "f262fa7c-e34f-4f68-a4fa-bc820e0d09f8" });

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "1ae444f0-3d96-4fb6-bdfb-285e7c6da675");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "f262fa7c-e34f-4f68-a4fa-bc820e0d09f8");

            migrationBuilder.DropColumn(
                name: "IsOpen",
                table: "Challenges");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "27bdf5ef-cbfa-4219-8802-ef38c0e722e5", "0ce6a689-eb1e-404b-b87d-d06e66111449", "SuperAdmin", "SUPERADMIN" },
                    { "6149c78a-91b3-4194-babf-a891f770504c", "76ea9e78-ec9c-4f21-88aa-919e6574d8f5", "Admin", "ADMIN" },
                    { "80db3ff6-0ac8-415b-a431-57701c3287b2", "efcbe062-5d5f-4f55-9353-086c5c159e92", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "43ffa0c4-ea2c-4b23-a191-e981c81ae341", 0, "9e5e77c3-27b0-4ded-84a0-57f23bba4629", null, false, false, null, null, "SUPERADMIN", "AQAAAAIAAYagAAAAEFyCqs1xE9BbsDnQck0wLNgl4ob05zLkywJ2jNeFBu4NmzFQz7QlAjdgUmI8PaIJ/w==", null, false, "fcc79220-868d-4582-bde2-5740ca758a53", false, "superadmin" });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "27bdf5ef-cbfa-4219-8802-ef38c0e722e5", "43ffa0c4-ea2c-4b23-a191-e981c81ae341" });
        }
    }
}

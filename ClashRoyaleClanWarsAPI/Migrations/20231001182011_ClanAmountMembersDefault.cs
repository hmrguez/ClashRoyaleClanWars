using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ClashRoyaleClanWarsAPI.Migrations
{
    /// <inheritdoc />
    public partial class ClanAmountMembersDefault : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_Cards_FavoriteCardId",
                table: "Players");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "86773243-8e36-4a71-a389-956ce4c9f738");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "8f3ffbc7-e442-4bfb-9c29-ae0c3375c4c4");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "7b5b5cb2-4cbe-406e-b48a-8d1f32778c1c", "a4e0935e-e864-40fa-8133-06605816c5ca" });

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "7b5b5cb2-4cbe-406e-b48a-8d1f32778c1c");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "a4e0935e-e864-40fa-8133-06605816c5ca");

            migrationBuilder.AlterColumn<int>(
                name: "FavoriteCardId",
                table: "Players",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "697f1925-86eb-43da-8176-37b572fad0c4", "c629d09c-b55a-4198-b0d1-9a74793153dd", "User", "USER" },
                    { "8fb28309-0ca1-4685-b0a5-9fe3c9f7d5c3", "78125589-f9b6-4445-87b0-43371836c475", "SuperAdmin", "SUPERADMIN" },
                    { "9c892de0-0c28-4d8e-977d-920f78516d4b", "f81816fe-38c1-444c-8c6e-a94cc98d1181", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "e429fd44-326c-4164-b60a-5c110136093f", 0, "7a648fb9-72cf-4eab-9ae2-8f3b6d1188b4", null, false, false, null, null, "SUPERADMIN", "AQAAAAIAAYagAAAAEMsnWf1Epd8g5k988OaNBS5WWx4l0H6J5VD90RX9VnlZTZSfrhUcI4GP6APgejgAFw==", null, false, "41f4d935-5997-429d-a494-c481289e5341", false, "superadmin" });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "8fb28309-0ca1-4685-b0a5-9fe3c9f7d5c3", "e429fd44-326c-4164-b60a-5c110136093f" });

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Cards_FavoriteCardId",
                table: "Players",
                column: "FavoriteCardId",
                principalTable: "Cards",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_Cards_FavoriteCardId",
                table: "Players");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "697f1925-86eb-43da-8176-37b572fad0c4");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "9c892de0-0c28-4d8e-977d-920f78516d4b");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "8fb28309-0ca1-4685-b0a5-9fe3c9f7d5c3", "e429fd44-326c-4164-b60a-5c110136093f" });

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "8fb28309-0ca1-4685-b0a5-9fe3c9f7d5c3");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "e429fd44-326c-4164-b60a-5c110136093f");

            migrationBuilder.AlterColumn<int>(
                name: "FavoriteCardId",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7b5b5cb2-4cbe-406e-b48a-8d1f32778c1c", "f0fd69b6-6259-43ab-8d23-fd88a9f4c688", "SuperAdmin", "SUPERADMIN" },
                    { "86773243-8e36-4a71-a389-956ce4c9f738", "222481c0-51c4-4bb1-8d4e-b68ba2979cab", "User", "USER" },
                    { "8f3ffbc7-e442-4bfb-9c29-ae0c3375c4c4", "697b2f1f-ca54-4ac7-9fc5-774e21b36567", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "a4e0935e-e864-40fa-8133-06605816c5ca", 0, "e9ef5b09-d307-4bfd-b6bf-71e48e3720d0", null, false, false, null, null, "SUPERADMIN", "AQAAAAIAAYagAAAAEHnuwmha787VczHAk9UDUtn0aZ+8QbCgtk4hrPJ3rVM/BPLHGRRMedwCvA0b73nu+g==", null, false, "c45bb5a4-1719-4b3d-96d0-c0f670d00567", false, "superadmin" });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "7b5b5cb2-4cbe-406e-b48a-8d1f32778c1c", "a4e0935e-e864-40fa-8133-06605816c5ca" });

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Cards_FavoriteCardId",
                table: "Players",
                column: "FavoriteCardId",
                principalTable: "Cards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

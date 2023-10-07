using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ClashRoyaleClanWarsAPI.Migrations
{
    /// <inheritdoc />
    public partial class BattleDateColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Battles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4e24c939-1bab-42a3-b6da-2b63ba90f254", "5112b2df-c7ab-48ef-9b0c-0f72d623b9d2", "User", "USER" },
                    { "83b72a42-6b95-477a-8637-1626a8b6a979", "857bf47c-cbf0-44f2-b3b7-9c053cf44870", "Admin", "ADMIN" },
                    { "c1602929-02c2-4b1e-b946-44da7a758587", "db69c8c8-d9d3-41fb-b2a5-8cc9391025a4", "SuperAdmin", "SUPERADMIN" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "157e61fe-8baa-49b4-8936-2e1e8b8148d9", 0, "7b383a12-c3e8-43f2-8434-4b0b18461c9d", null, false, false, null, null, "SUPERADMIN", "AQAAAAIAAYagAAAAEOai7L4w0DBwJqGdehw3Y9/MY1HvaTrmy+ifn2MYq4tPdr6wrgo2wmOk45n5n6HZIw==", null, false, "1b0fc554-02bf-4b05-990d-ece66db6ae2f", false, "superadmin" });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "c1602929-02c2-4b1e-b946-44da7a758587", "157e61fe-8baa-49b4-8936-2e1e8b8148d9" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "4e24c939-1bab-42a3-b6da-2b63ba90f254");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "83b72a42-6b95-477a-8637-1626a8b6a979");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c1602929-02c2-4b1e-b946-44da7a758587", "157e61fe-8baa-49b4-8936-2e1e8b8148d9" });

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "c1602929-02c2-4b1e-b946-44da7a758587");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "157e61fe-8baa-49b4-8936-2e1e8b8148d9");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Battles");

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
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ClashRoyaleClanWarsAPI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixingSuperAdminRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("aa8f19cf-9a70-4b70-ae92-e67e42120122"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("b225e79f-d3c1-49fe-9dce-06ae22cbfeaf"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("ffd134e8-96ca-40e9-9e69-84b4e18c4c0a"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("fdc931b1-c3e8-49fd-b201-dd2b6f02bc65"));

            migrationBuilder.AlterColumn<Guid>(
                name: "RoleId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("04c5facd-f8f5-4178-a62e-b207dda79f28"), "Admin" },
                    { new Guid("11392600-c6b2-4ea9-b4dc-b03c005e6259"), "SuperAdmin" },
                    { new Guid("f31ee98c-407a-406c-b855-6fdfceaba167"), "User" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "PasswordHash", "PlayerId", "RoleId", "UserName" },
                values: new object[] { new Guid("eb8ec7ef-d354-4a80-80cb-c6cf0a1ad43a"), "AQAAAAIAAYagAAAAEEEACElCPkJxaCpbgV+wH3Q3kRZoskgcWHqXEEQlLseBzF2zrWg/hs5cO1MPtu4WXA==", null, new Guid("11392600-c6b2-4ea9-b4dc-b03c005e6259"), "superadmin" });

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("04c5facd-f8f5-4178-a62e-b207dda79f28"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("f31ee98c-407a-406c-b855-6fdfceaba167"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("eb8ec7ef-d354-4a80-80cb-c6cf0a1ad43a"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("11392600-c6b2-4ea9-b4dc-b03c005e6259"));

            migrationBuilder.AlterColumn<Guid>(
                name: "RoleId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("aa8f19cf-9a70-4b70-ae92-e67e42120122"), "User" },
                    { new Guid("b225e79f-d3c1-49fe-9dce-06ae22cbfeaf"), "SuperAdmin" },
                    { new Guid("ffd134e8-96ca-40e9-9e69-84b4e18c4c0a"), "Admin" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "PasswordHash", "PlayerId", "RoleId", "UserName" },
                values: new object[] { new Guid("fdc931b1-c3e8-49fd-b201-dd2b6f02bc65"), "AQAAAAIAAYagAAAAEJ57UyoO2lh9/HwCDUr/CiUXek0mgnMxdWSGBa2HpU+i97XD4pZ8ezQWjtd3BJVLeQ==", null, null, "superadmin" });

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ClashRoyaleClanWarsAPI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixingClanWarRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0e4158cb-5118-49bc-8d8b-634b83a679d3"), "Admin" },
                    { new Guid("8ea53a55-3374-4f91-b908-6bc3e7c0ebd9"), "SuperAdmin" },
                    { new Guid("9972ecb9-9c4e-4c25-b225-1df7152355c2"), "User" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "PasswordHash", "PlayerId", "RoleId", "UserName" },
                values: new object[] { new Guid("fc7b9856-8d1c-471a-82b9-28b57937590f"), "AQAAAAIAAYagAAAAEHVp0icU79hbXi5cBtUgZ87/SUaTEtPLOGRfT/yoQkaE/AucGOWB/RfuTIWeG/N5GQ==", null, new Guid("8ea53a55-3374-4f91-b908-6bc3e7c0ebd9"), "superadmin" });

            migrationBuilder.CreateIndex(
                name: "IX_ClanWars_ClanId",
                table: "ClanWars",
                column: "ClanId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ClanWars_ClanId",
                table: "ClanWars");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("0e4158cb-5118-49bc-8d8b-634b83a679d3"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("9972ecb9-9c4e-4c25-b225-1df7152355c2"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("fc7b9856-8d1c-471a-82b9-28b57937590f"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("8ea53a55-3374-4f91-b908-6bc3e7c0ebd9"));

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
        }
    }
}

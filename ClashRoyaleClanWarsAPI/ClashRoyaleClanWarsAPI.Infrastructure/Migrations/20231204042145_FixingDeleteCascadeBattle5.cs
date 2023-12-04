using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ClashRoyaleClanWarsAPI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixingDeleteCascadeBattle5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Battles_Players_LoserId",
                table: "Battles");

            migrationBuilder.DropForeignKey(
                name: "FK_Battles_Players_WinnerId",
                table: "Battles");

            migrationBuilder.DropForeignKey(
                name: "FK_Donations_Players_PlayerId",
                table: "Donations");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("388e522d-e530-440a-96b0-c933ac50e8cb"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("aff1ba23-e886-4819-b36d-083bcb8e58b5"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0203aaa8-7c6e-494e-9e97-506dccd4e1dd"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("d3e9b40e-305b-4e0c-9070-6dea126711f4"));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("471c2ac5-dd9c-46a1-b104-01d05ad234dd"), "User" },
                    { new Guid("532a2e25-c262-47f9-bf8b-48b07e84639f"), "Admin" },
                    { new Guid("7a509152-925f-475e-8118-b24c588a80b1"), "SuperAdmin" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "PasswordHash", "PlayerId", "RoleId", "UserName" },
                values: new object[] { new Guid("8bcbfc62-b9a3-4456-b9ba-2ee1db9531a4"), "AQAAAAIAAYagAAAAEARPD825gaw+PV4p6Nz40pFoLkKUiSZ3nmLl7+/5v+RR8haWZMc3aeLNrbgVOaJCWw==", null, new Guid("7a509152-925f-475e-8118-b24c588a80b1"), "superadmin" });

            migrationBuilder.AddForeignKey(
                name: "FK_Battles_Players_LoserId",
                table: "Battles",
                column: "LoserId",
                principalTable: "Players",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Battles_Players_WinnerId",
                table: "Battles",
                column: "WinnerId",
                principalTable: "Players",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Donations_Players_PlayerId",
                table: "Donations",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Battles_Players_LoserId",
                table: "Battles");

            migrationBuilder.DropForeignKey(
                name: "FK_Battles_Players_WinnerId",
                table: "Battles");

            migrationBuilder.DropForeignKey(
                name: "FK_Donations_Players_PlayerId",
                table: "Donations");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("471c2ac5-dd9c-46a1-b104-01d05ad234dd"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("532a2e25-c262-47f9-bf8b-48b07e84639f"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("8bcbfc62-b9a3-4456-b9ba-2ee1db9531a4"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("7a509152-925f-475e-8118-b24c588a80b1"));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("388e522d-e530-440a-96b0-c933ac50e8cb"), "User" },
                    { new Guid("aff1ba23-e886-4819-b36d-083bcb8e58b5"), "Admin" },
                    { new Guid("d3e9b40e-305b-4e0c-9070-6dea126711f4"), "SuperAdmin" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "PasswordHash", "PlayerId", "RoleId", "UserName" },
                values: new object[] { new Guid("0203aaa8-7c6e-494e-9e97-506dccd4e1dd"), "AQAAAAIAAYagAAAAECGzqO3mclGd+wXMY7dV8h8kNOQ5MQ38mrf9JVuNdMYpbWOdsOg2wUc1LKklPt0cvQ==", null, new Guid("d3e9b40e-305b-4e0c-9070-6dea126711f4"), "superadmin" });

            migrationBuilder.AddForeignKey(
                name: "FK_Battles_Players_LoserId",
                table: "Battles",
                column: "LoserId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Battles_Players_WinnerId",
                table: "Battles",
                column: "WinnerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Donations_Players_PlayerId",
                table: "Donations",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id");
        }
    }
}

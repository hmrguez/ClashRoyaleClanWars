using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ClashRoyaleClanWarsAPI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixingDeleteCascadeBattle4 : Migration
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

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("126f017a-6d69-4d17-bc5c-c7bb8d76c31b"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("9d1b3a6a-3995-4a9a-b796-e947eb0d0fe9"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("50812570-3f33-4623-b3fe-7efce29194c6"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("0ca7afb9-11ff-4e8a-a468-0cb77f0726e3"));

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
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Battles_Players_WinnerId",
                table: "Battles",
                column: "WinnerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Battles_Players_LoserId",
                table: "Battles");

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
                    { new Guid("0ca7afb9-11ff-4e8a-a468-0cb77f0726e3"), "SuperAdmin" },
                    { new Guid("126f017a-6d69-4d17-bc5c-c7bb8d76c31b"), "Admin" },
                    { new Guid("9d1b3a6a-3995-4a9a-b796-e947eb0d0fe9"), "User" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "PasswordHash", "PlayerId", "RoleId", "UserName" },
                values: new object[] { new Guid("50812570-3f33-4623-b3fe-7efce29194c6"), "AQAAAAIAAYagAAAAEKdZGTZEgQMzCd3Pfz4dk/vTukHDNfdonXG6a4rXCivKZnvrRso4io7UGSahnzcAMA==", null, new Guid("0ca7afb9-11ff-4e8a-a468-0cb77f0726e3"), "superadmin" });

            migrationBuilder.AddForeignKey(
                name: "FK_Battles_Players_LoserId",
                table: "Battles",
                column: "LoserId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

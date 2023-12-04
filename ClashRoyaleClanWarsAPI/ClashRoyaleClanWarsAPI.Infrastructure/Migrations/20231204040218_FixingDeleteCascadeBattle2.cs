using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ClashRoyaleClanWarsAPI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixingDeleteCascadeBattle2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("cd899cc6-f0cf-476d-abc5-f57d29847083"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("e81d1b7f-bab6-4ab7-8171-4b64a2ea4488"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c7994bf3-b8ff-473b-ae81-5ef302992b9b"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("80468884-7a97-4e27-af32-39e990f4e754"));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0217c48d-0d9f-4d46-81a6-ae9d21bd270e"), "Admin" },
                    { new Guid("5a202b41-4249-4ddf-89cf-6d3412826d75"), "User" },
                    { new Guid("60731f7a-dabe-43ae-b77d-a68728e90466"), "SuperAdmin" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "PasswordHash", "PlayerId", "RoleId", "UserName" },
                values: new object[] { new Guid("9afddf5a-da14-4f85-8cda-705e577863f2"), "AQAAAAIAAYagAAAAED5l0S+pkK3F6gB2RjI5rzGgWG/7KOJixuUkRYFfGVrcsOemO47rYD+6un3IOOi1iQ==", null, new Guid("60731f7a-dabe-43ae-b77d-a68728e90466"), "superadmin" });

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Battles_LoserId",
                table: "Battles");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("0217c48d-0d9f-4d46-81a6-ae9d21bd270e"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("5a202b41-4249-4ddf-89cf-6d3412826d75"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("9afddf5a-da14-4f85-8cda-705e577863f2"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("60731f7a-dabe-43ae-b77d-a68728e90466"));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("80468884-7a97-4e27-af32-39e990f4e754"), "SuperAdmin" },
                    { new Guid("cd899cc6-f0cf-476d-abc5-f57d29847083"), "User" },
                    { new Guid("e81d1b7f-bab6-4ab7-8171-4b64a2ea4488"), "Admin" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "PasswordHash", "PlayerId", "RoleId", "UserName" },
                values: new object[] { new Guid("c7994bf3-b8ff-473b-ae81-5ef302992b9b"), "AQAAAAIAAYagAAAAENtuD3H4H6FH0VrPdrrG7WyIgBcLwb8g18dXsXYkOu2NnU0klb2AjmweUOhZN1k38A==", null, new Guid("80468884-7a97-4e27-af32-39e990f4e754"), "superadmin" });
        }
    }
}

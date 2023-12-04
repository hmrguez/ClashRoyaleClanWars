using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ClashRoyaleClanWarsAPI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixingDeleteCascadeBattle1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("0e4158cb-5118-49bc-8d8b-634b83a679d3"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("8ea53a55-3374-4f91-b908-6bc3e7c0ebd9"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("fc7b9856-8d1c-471a-82b9-28b57937590f"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("9972ecb9-9c4e-4c25-b225-1df7152355c2"));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { new Guid("04c05306-9465-4df4-b94c-8b775ac15edd"), "User" },
                    { new Guid("ed764011-0e1e-40fc-9ff4-9f4eec2f0bc2"), "SuperAdmin" },
                    { new Guid("f8409d26-d545-430b-97d0-e66b483cb457"), "Admin" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "PasswordHash", "PlayerId", "RoleId", "UserName" },
                values: new object[] { new Guid("13cfea37-9e77-4196-9d71-395c26e74e3e"), "AQAAAAIAAYagAAAAEOtFM+sHJ6BU9feqAfONeWbggArc6WDV3CV0zNbrR+VoJ1T7r1K8mZm8+HLeJTMdCA==", null, new Guid("ed764011-0e1e-40fc-9ff4-9f4eec2f0bc2"), "superadmin" });
        }
    }
}

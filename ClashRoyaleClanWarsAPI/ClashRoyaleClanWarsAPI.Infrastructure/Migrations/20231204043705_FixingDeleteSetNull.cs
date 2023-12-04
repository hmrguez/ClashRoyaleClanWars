using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ClashRoyaleClanWarsAPI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixingDeleteSetNull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Players_PlayerId",
                table: "Users");

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
                    { new Guid("a865afd6-72e3-48d3-b19f-0ae8fff10bed"), "Admin" },
                    { new Guid("b6b3b663-6d61-4456-bf1a-61cac4d9d325"), "SuperAdmin" },
                    { new Guid("f64ed1db-1fea-4aaf-8bf9-43e37a00744d"), "User" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "PasswordHash", "PlayerId", "RoleId", "UserName" },
                values: new object[] { new Guid("99800825-dba7-4ef2-bfae-497a66cb59e2"), "AQAAAAIAAYagAAAAECaap99Oqd4wA00Sj3Qn7RwntbHIcuhh996fkAkHNV4pZa/B5wVZXQbiJJtEUPZdhw==", null, new Guid("b6b3b663-6d61-4456-bf1a-61cac4d9d325"), "superadmin" });

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Players_PlayerId",
                table: "Users",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Players_PlayerId",
                table: "Users");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("a865afd6-72e3-48d3-b19f-0ae8fff10bed"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("f64ed1db-1fea-4aaf-8bf9-43e37a00744d"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("99800825-dba7-4ef2-bfae-497a66cb59e2"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("b6b3b663-6d61-4456-bf1a-61cac4d9d325"));

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
                name: "FK_Users_Players_PlayerId",
                table: "Users",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id");
        }
    }
}

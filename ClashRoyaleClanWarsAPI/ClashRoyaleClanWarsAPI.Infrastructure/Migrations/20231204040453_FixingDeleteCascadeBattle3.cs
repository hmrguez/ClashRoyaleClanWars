using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ClashRoyaleClanWarsAPI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixingDeleteCascadeBattle3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    { new Guid("0ca7afb9-11ff-4e8a-a468-0cb77f0726e3"), "SuperAdmin" },
                    { new Guid("126f017a-6d69-4d17-bc5c-c7bb8d76c31b"), "Admin" },
                    { new Guid("9d1b3a6a-3995-4a9a-b796-e947eb0d0fe9"), "User" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "PasswordHash", "PlayerId", "RoleId", "UserName" },
                values: new object[] { new Guid("50812570-3f33-4623-b3fe-7efce29194c6"), "AQAAAAIAAYagAAAAEKdZGTZEgQMzCd3Pfz4dk/vTukHDNfdonXG6a4rXCivKZnvrRso4io7UGSahnzcAMA==", null, new Guid("0ca7afb9-11ff-4e8a-a468-0cb77f0726e3"), "superadmin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                    { new Guid("0217c48d-0d9f-4d46-81a6-ae9d21bd270e"), "Admin" },
                    { new Guid("5a202b41-4249-4ddf-89cf-6d3412826d75"), "User" },
                    { new Guid("60731f7a-dabe-43ae-b77d-a68728e90466"), "SuperAdmin" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "PasswordHash", "PlayerId", "RoleId", "UserName" },
                values: new object[] { new Guid("9afddf5a-da14-4f85-8cda-705e577863f2"), "AQAAAAIAAYagAAAAED5l0S+pkK3F6gB2RjI5rzGgWG/7KOJixuUkRYFfGVrcsOemO47rYD+6un3IOOi1iQ==", null, new Guid("60731f7a-dabe-43ae-b77d-a68728e90466"), "superadmin" });
        }
    }
}

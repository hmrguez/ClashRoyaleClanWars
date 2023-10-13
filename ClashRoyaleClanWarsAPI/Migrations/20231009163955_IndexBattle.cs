using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClashRoyaleClanWarsAPI.Migrations
{
    /// <inheritdoc />
    public partial class IndexBattle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Battles_WinnerId",
                table: "Battles");

            migrationBuilder.CreateIndex(
                name: "IX_Battles_WinnerId_LoserId_Date",
                table: "Battles",
                columns: new[] { "WinnerId", "LoserId", "Date" },
                unique: true,
                filter: "[WinnerId] IS NOT NULL AND [LoserId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Battles_WinnerId_LoserId_Date",
                table: "Battles");

            migrationBuilder.CreateIndex(
                name: "IX_Battles_WinnerId",
                table: "Battles",
                column: "WinnerId");
        }
    }
}

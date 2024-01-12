using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gudang_Super_Market.Migrations
{
    public partial class gudangsupermarket_v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Gudangs_NamaGudang",
                table: "Gudangs",
                column: "NamaGudang",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Gudangs_NamaGudang",
                table: "Gudangs");
        }
    }
}

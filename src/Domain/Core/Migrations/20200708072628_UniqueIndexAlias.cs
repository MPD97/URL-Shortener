using Microsoft.EntityFrameworkCore.Migrations;

namespace Core.Migrations
{
    public partial class UniqueIndexAlias : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Shortcuts_Alias",
                table: "Shortcuts",
                column: "Alias",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Shortcuts_Alias",
                table: "Shortcuts");
        }
    }
}

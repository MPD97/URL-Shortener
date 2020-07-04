using Microsoft.EntityFrameworkCore.Migrations;

namespace Core.Migrations
{
    public partial class ShortcutEntityHasOptionalRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Shortcuts_RedirectExtendedId",
                table: "Shortcuts");

            migrationBuilder.DropIndex(
                name: "IX_Shortcuts_RedirectId",
                table: "Shortcuts");

            migrationBuilder.AlterColumn<long>(
                name: "RedirectId",
                table: "Shortcuts",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "RedirectExtendedId",
                table: "Shortcuts",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.CreateIndex(
                name: "IX_Shortcuts_RedirectExtendedId",
                table: "Shortcuts",
                column: "RedirectExtendedId",
                unique: true,
                filter: "[RedirectExtendedId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Shortcuts_RedirectId",
                table: "Shortcuts",
                column: "RedirectId",
                unique: true,
                filter: "[RedirectId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Shortcuts_RedirectExtendedId",
                table: "Shortcuts");

            migrationBuilder.DropIndex(
                name: "IX_Shortcuts_RedirectId",
                table: "Shortcuts");

            migrationBuilder.AlterColumn<long>(
                name: "RedirectId",
                table: "Shortcuts",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "RedirectExtendedId",
                table: "Shortcuts",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Shortcuts_RedirectExtendedId",
                table: "Shortcuts",
                column: "RedirectExtendedId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Shortcuts_RedirectId",
                table: "Shortcuts",
                column: "RedirectId",
                unique: true);
        }
    }
}

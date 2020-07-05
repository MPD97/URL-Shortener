using Microsoft.EntityFrameworkCore.Migrations;

namespace Core.Migrations
{
    public partial class AddedFluentApi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RedirectExtended_Shortcut_ShortcutId",
                table: "RedirectExtended");

            migrationBuilder.DropForeignKey(
                name: "FK_Redirects_Shortcut_ShortcutId",
                table: "Redirects");

            migrationBuilder.DropIndex(
                name: "IX_Redirects_ShortcutId",
                table: "Redirects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Shortcut",
                table: "Shortcut");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RedirectExtended",
                table: "RedirectExtended");

            migrationBuilder.DropIndex(
                name: "IX_RedirectExtended_ShortcutId",
                table: "RedirectExtended");

            migrationBuilder.RenameTable(
                name: "Shortcut",
                newName: "Shortcuts");

            migrationBuilder.RenameTable(
                name: "RedirectExtended",
                newName: "RedirectExtendeds");

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "Redirects",
                maxLength: 80,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Alias",
                table: "Shortcuts",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TimesRedirect",
                table: "Shortcuts",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "RedirectExtendeds",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Shortcuts",
                table: "Shortcuts",
                column: "ShortcutId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RedirectExtendeds",
                table: "RedirectExtendeds",
                column: "RedirectExtendedId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Shortcuts_RedirectExtendeds_RedirectExtendedId",
                table: "Shortcuts",
                column: "RedirectExtendedId",
                principalTable: "RedirectExtendeds",
                principalColumn: "RedirectExtendedId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Shortcuts_Redirects_RedirectId",
                table: "Shortcuts",
                column: "RedirectId",
                principalTable: "Redirects",
                principalColumn: "RedirectId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shortcuts_RedirectExtendeds_RedirectExtendedId",
                table: "Shortcuts");

            migrationBuilder.DropForeignKey(
                name: "FK_Shortcuts_Redirects_RedirectId",
                table: "Shortcuts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Shortcuts",
                table: "Shortcuts");

            migrationBuilder.DropIndex(
                name: "IX_Shortcuts_RedirectExtendedId",
                table: "Shortcuts");

            migrationBuilder.DropIndex(
                name: "IX_Shortcuts_RedirectId",
                table: "Shortcuts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RedirectExtendeds",
                table: "RedirectExtendeds");

            migrationBuilder.DropColumn(
                name: "TimesRedirect",
                table: "Shortcuts");

            migrationBuilder.RenameTable(
                name: "Shortcuts",
                newName: "Shortcut");

            migrationBuilder.RenameTable(
                name: "RedirectExtendeds",
                newName: "RedirectExtended");

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "Redirects",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 80);

            migrationBuilder.AlterColumn<string>(
                name: "Alias",
                table: "Shortcut",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "RedirectExtended",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 1000);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Shortcut",
                table: "Shortcut",
                column: "ShortcutId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RedirectExtended",
                table: "RedirectExtended",
                column: "RedirectExtendedId");

            migrationBuilder.CreateIndex(
                name: "IX_Redirects_ShortcutId",
                table: "Redirects",
                column: "ShortcutId");

            migrationBuilder.CreateIndex(
                name: "IX_RedirectExtended_ShortcutId",
                table: "RedirectExtended",
                column: "ShortcutId");

            migrationBuilder.AddForeignKey(
                name: "FK_RedirectExtended_Shortcut_ShortcutId",
                table: "RedirectExtended",
                column: "ShortcutId",
                principalTable: "Shortcut",
                principalColumn: "ShortcutId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Redirects_Shortcut_ShortcutId",
                table: "Redirects",
                column: "ShortcutId",
                principalTable: "Shortcut",
                principalColumn: "ShortcutId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

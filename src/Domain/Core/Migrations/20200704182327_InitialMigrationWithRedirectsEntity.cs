using Microsoft.EntityFrameworkCore.Migrations;

namespace Core.Migrations
{
    public partial class InitialMigrationWithRedirectsEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Shortcut",
                columns: table => new
                {
                    ShortcutId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Alias = table.Column<string>(nullable: true),
                    RedirectId = table.Column<long>(nullable: false),
                    RedirectExtendedId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shortcut", x => x.ShortcutId);
                });

            migrationBuilder.CreateTable(
                name: "RedirectExtended",
                columns: table => new
                {
                    RedirectExtendedId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(nullable: true),
                    ShortcutId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RedirectExtended", x => x.RedirectExtendedId);
                    table.ForeignKey(
                        name: "FK_RedirectExtended_Shortcut_ShortcutId",
                        column: x => x.ShortcutId,
                        principalTable: "Shortcut",
                        principalColumn: "ShortcutId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Redirects",
                columns: table => new
                {
                    RedirectId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(nullable: true),
                    ShortcutId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Redirects", x => x.RedirectId);
                    table.ForeignKey(
                        name: "FK_Redirects_Shortcut_ShortcutId",
                        column: x => x.ShortcutId,
                        principalTable: "Shortcut",
                        principalColumn: "ShortcutId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RedirectExtended_ShortcutId",
                table: "RedirectExtended",
                column: "ShortcutId");

            migrationBuilder.CreateIndex(
                name: "IX_Redirects_ShortcutId",
                table: "Redirects",
                column: "ShortcutId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RedirectExtended");

            migrationBuilder.DropTable(
                name: "Redirects");

            migrationBuilder.DropTable(
                name: "Shortcut");
        }
    }
}

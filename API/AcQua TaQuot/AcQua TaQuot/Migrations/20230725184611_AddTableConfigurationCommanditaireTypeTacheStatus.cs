using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AcQua_TaQuot.Migrations
{
    public partial class AddTableConfigurationCommanditaireTypeTacheStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConfigurationCommanditaireTypeTacheStatuts",
                columns: table => new
                {
                    CommanditaireId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TypeTacheId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StatutId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfigurationCommanditaireTypeTacheStatuts", x => new { x.CommanditaireId, x.TypeTacheId });
                    table.ForeignKey(
                        name: "FK_ConfigurationCommanditaireTypeTacheStatuts_Commanditaires_CommanditaireId",
                        column: x => x.CommanditaireId,
                        principalTable: "Commanditaires",
                        principalColumn: "CommanditaireId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConfigurationCommanditaireTypeTacheStatuts_Statuts_StatutId",
                        column: x => x.StatutId,
                        principalTable: "Statuts",
                        principalColumn: "StatutId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConfigurationCommanditaireTypeTacheStatuts_TypesTache_TypeTacheId",
                        column: x => x.TypeTacheId,
                        principalTable: "TypesTache",
                        principalColumn: "TypeTacheId",
                        onDelete: ReferentialAction.Cascade);
                });


            migrationBuilder.CreateIndex(
                name: "IX_ConfigurationCommanditaireTypeTacheStatuts_StatutId",
                table: "ConfigurationCommanditaireTypeTacheStatuts",
                column: "StatutId");

            migrationBuilder.CreateIndex(
                name: "IX_ConfigurationCommanditaireTypeTacheStatuts_TypeTacheId",
                table: "ConfigurationCommanditaireTypeTacheStatuts",
                column: "TypeTacheId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConfigurationCommanditaireTypeTacheStatuts");
        }
    }
}

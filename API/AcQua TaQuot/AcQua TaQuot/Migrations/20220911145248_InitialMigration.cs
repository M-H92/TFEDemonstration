using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AcQua_TaQuot.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Commanditaires",
                columns: table => new
                {
                    CommanditaireId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commanditaires", x => x.CommanditaireId);
                });

            migrationBuilder.CreateTable(
                name: "Statuts",
                columns: table => new
                {
                    StatutId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Libelle = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuts", x => x.StatutId);
                });

            migrationBuilder.CreateTable(
                name: "TypesTache",
                columns: table => new
                {
                    TypeTacheId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Libelle = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypesTache", x => x.TypeTacheId);
                });

            migrationBuilder.CreateTable(
                name: "Applications",
                columns: table => new
                {
                    ApplicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Libelle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommanditaireId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applications", x => x.ApplicationId);
                    table.ForeignKey(
                        name: "FK_Applications_Commanditaires_CommanditaireId",
                        column: x => x.CommanditaireId,
                        principalTable: "Commanditaires",
                        principalColumn: "CommanditaireId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prices",
                columns: table => new
                {
                    PrixId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateDebut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Valeur = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TauxTVA = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CommanditaireId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prices", x => x.PrixId);
                    table.ForeignKey(
                        name: "FK_Prices_Commanditaires_CommanditaireId",
                        column: x => x.CommanditaireId,
                        principalTable: "Commanditaires",
                        principalColumn: "CommanditaireId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prestations",
                columns: table => new
                {
                    PrestationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IssueGitLab = table.Column<int>(type: "int", nullable: false),
                    Commentaire = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Temps = table.Column<int>(type: "int", nullable: false),
                    IsFacturable = table.Column<bool>(type: "bit", nullable: false),
                    Utilisateur = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    TypeTacheId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StatutId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prestations", x => x.PrestationId);
                    table.ForeignKey(
                        name: "FK_Prestations_Statuts_StatutId",
                        column: x => x.StatutId,
                        principalTable: "Statuts",
                        principalColumn: "StatutId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prestations_TypesTache_TypeTacheId",
                        column: x => x.TypeTacheId,
                        principalTable: "TypesTache",
                        principalColumn: "TypeTacheId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Modules",
                columns: table => new
                {
                    ModuleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Libelle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApplicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modules", x => x.ModuleId);
                    table.ForeignKey(
                        name: "FK_Modules_Applications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "Applications",
                        principalColumn: "ApplicationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LignesFacture",
                columns: table => new
                {
                    LigneFactureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MoisFacturation = table.Column<int>(type: "int", nullable: false),
                    PrixUnitaire = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantite = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PrestationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LignesFacture", x => x.LigneFactureId);
                    table.ForeignKey(
                        name: "FK_LignesFacture_Prestations_PrestationId",
                        column: x => x.PrestationId,
                        principalTable: "Prestations",
                        principalColumn: "PrestationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Taches",
                columns: table => new
                {
                    TacheId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Libelle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModuleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PrestationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Taches", x => x.TacheId);
                    table.ForeignKey(
                        name: "FK_Taches_Modules_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "Modules",
                        principalColumn: "ModuleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Taches_Prestations_PrestationId",
                        column: x => x.PrestationId,
                        principalTable: "Prestations",
                        principalColumn: "PrestationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Applications_CommanditaireId",
                table: "Applications",
                column: "CommanditaireId");

            migrationBuilder.CreateIndex(
                name: "IX_LignesFacture_PrestationId",
                table: "LignesFacture",
                column: "PrestationId");

            migrationBuilder.CreateIndex(
                name: "IX_Modules_ApplicationId",
                table: "Modules",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_Prestations_StatutId",
                table: "Prestations",
                column: "StatutId");

            migrationBuilder.CreateIndex(
                name: "IX_Prestations_TypeTacheId",
                table: "Prestations",
                column: "TypeTacheId");

            migrationBuilder.CreateIndex(
                name: "IX_Prices_CommanditaireId",
                table: "Prices",
                column: "CommanditaireId");

            migrationBuilder.CreateIndex(
                name: "IX_Taches_ModuleId",
                table: "Taches",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_Taches_PrestationId",
                table: "Taches",
                column: "PrestationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LignesFacture");

            migrationBuilder.DropTable(
                name: "Prices");

            migrationBuilder.DropTable(
                name: "Taches");

            migrationBuilder.DropTable(
                name: "Modules");

            migrationBuilder.DropTable(
                name: "Prestations");

            migrationBuilder.DropTable(
                name: "Applications");

            migrationBuilder.DropTable(
                name: "Statuts");

            migrationBuilder.DropTable(
                name: "TypesTache");

            migrationBuilder.DropTable(
                name: "Commanditaires");
        }
    }
}

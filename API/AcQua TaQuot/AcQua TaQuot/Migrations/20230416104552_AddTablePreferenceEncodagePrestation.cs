using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AcQua_TaQuot.Migrations
{
    public partial class AddTablePreferenceEncodagePrestation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PreferencesEncodagePrestation",
                columns: table => new
                {
                    PreferenceEncodagePrestationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Utilisateur = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    ResetTypeTache = table.Column<bool>(type: "bit", nullable: false),
                    ResetCommanditaire = table.Column<bool>(type: "bit", nullable: false),
                    ResetApplication = table.Column<bool>(type: "bit", nullable: false),
                    ResetModule = table.Column<bool>(type: "bit", nullable: false),
                    InitAtLastDate = table.Column<bool>(type: "bit", nullable: false),
                    TempsAsInputTypeTime = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreferencesEncodagePrestation", x => x.PreferenceEncodagePrestationId);
                });
            
            migrationBuilder.CreateIndex(
                name: "IX_PreferencesEncodagePrestation_Utilisateur",
                table: "PreferencesEncodagePrestation",
                column: "Utilisateur");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PreferencesEncodagePrestation");
            
        }
    }
}

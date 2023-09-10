using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AcQua_TaQuot.Migrations
{
    public partial class addTableRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Utilisateur = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Valeur = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Roles_Utilisateur",
                table: "Roles",
                column: "Utilisateur");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}

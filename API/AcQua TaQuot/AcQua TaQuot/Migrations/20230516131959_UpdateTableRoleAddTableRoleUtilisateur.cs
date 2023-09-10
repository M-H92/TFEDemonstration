using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AcQua_TaQuot.Migrations
{
    public partial class UpdateTableRoleAddTableRoleUtilisateur : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "RolesUtilisateurs",
                columns: table => new
                {
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Utilisateur = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolesUtilisateurs", x => new { x.RoleId, x.Utilisateur });
                    table.ForeignKey(
                        name: "FK_RolesUtilisateurs_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "Description" },
                values: new object[,]
                {
                    { "ADMIN", "Permet d'accéder à toutes les fonctionnalités." },
                    { "DEFAUT", "Rôle attribué par défaut à la création d'un utilisateur. Si il ne dispose que de ce rôle, il ne pourra accéder qu'à la page home." },
                    { "ENCODAGE", "Permet à l'utilisateur d'accéder à la page d'encodage et de créer, mettre à jour ou supprimer ses propres tâches quotidiennes." },
                    { "NIVEAUINF", "Permet à l'utilisateur de gérer le niveau inférieur des tâches quotidiennes. Par exemple, la création de modules." },
                    { "NIVEAUMOY", "Permet à l'utilisateur de gérer le niveau moyen des tâches quotidiennes. Par exemple, la création d'applications." },
                    { "NIVEAUSUP", "Permet à l'utilisateur de gérer le niveau supérieur des tâches quotidiennes. Par exemple, la création de commanditaires." },
                    { "RECAP", "Permet à l'utilisateur d'accéder à l'écran de récapitulatif hebdomadaire du temps de prestation." }
                });

            migrationBuilder.InsertData(
                table: "RolesUtilisateurs",
                columns: new[] { "RoleId", "Utilisateur" },
                values: new object[] { "ADMIN", "JGO" });

            migrationBuilder.CreateIndex(
                name: "IX_RolesUtilisateurs_RoleId",
                table: "RolesUtilisateurs",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_RolesUtilisateurs_Utilisateur",
                table: "RolesUtilisateurs",
                column: "Utilisateur");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RolesUtilisateurs");

            migrationBuilder.DropTable(
                name: "Roles");

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
    }
}

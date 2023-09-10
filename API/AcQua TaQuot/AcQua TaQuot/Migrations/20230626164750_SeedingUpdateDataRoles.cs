using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AcQua_TaQuot.Migrations
{
    public partial class SeedingUpdateDataRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "Description" },
                values: new object[,]
                {
                    { "FACTURATION", "Permet à l'utilisateur d'accéder à l'écran de facturation." },
                    { "STATS", "Permet à l'utilisateur d'accéder à l'écran de sprint review et de récapitulatif détaillé." }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: "FACTURATION");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: "STATS");
        }
    }
}

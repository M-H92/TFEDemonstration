using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AcQua_TaQuot.Migrations
{
    public partial class UpdateRelationTachePrestationOneToOne : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Taches_PrestationId",
                table: "Taches");

            
            migrationBuilder.UpdateData(
                table: "Statuts",
                keyColumn: "StatutId",
                keyValue: new Guid("a6209f00-e501-4a7c-9cbb-8ff410e9fbf7"),
                column: "Libelle",
                value: "A Facturer");

            migrationBuilder.InsertData(
                table: "Statuts",
                columns: new[] { "StatutId", "Libelle" },
                values: new object[,]
                {
                    { new Guid("4cfe1b05-a5dc-4c46-b9bc-288835116c0c"), "Non Facturable" },
                    { new Guid("b5f8fa4f-af89-4471-afb2-55d98eb61629"), "Facturé" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Taches_PrestationId",
                table: "Taches",
                column: "PrestationId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Taches_PrestationId",
                table: "Taches");

            
            migrationBuilder.UpdateData(
                table: "Statuts",
                keyColumn: "StatutId",
                keyValue: new Guid("a6209f00-e501-4a7c-9cbb-8ff410e9fbf7"),
                column: "Libelle",
                value: "A Facturé");

            migrationBuilder.InsertData(
                table: "Statuts",
                columns: new[] { "StatutId", "Libelle" },
                values: new object[,]
                {
                    { new Guid("08929527-2bc5-4e35-88ae-d17b95d43add"), "Facturé" },
                    { new Guid("e4ba9b11-0028-4d53-9dc0-6e63efa28504"), "Non Facturable" }
                });

            migrationBuilder.DeleteData(
                table: "Statuts",
                keyColumn: "StatutId",
                keyValue: new Guid("4cfe1b05-a5dc-4c46-b9bc-288835116c0c"));

            migrationBuilder.DeleteData(
                table: "Statuts",
                keyColumn: "StatutId",
                keyValue: new Guid("b5f8fa4f-af89-4471-afb2-55d98eb61629"));

            migrationBuilder.CreateIndex(
                name: "IX_Taches_PrestationId",
                table: "Taches",
                column: "PrestationId");
        }
    }
}

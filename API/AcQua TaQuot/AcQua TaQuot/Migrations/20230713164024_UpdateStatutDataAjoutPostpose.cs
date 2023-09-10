using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AcQua_TaQuot.Migrations
{
    public partial class UpdateStatutDataAjoutPostpose : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.InsertData(
                table: "Statuts",
                columns: new[] { "StatutId", "Libelle" },
                values: new object[] { new Guid("a9af7b59-2326-4b38-b214-7cf8bbf6d542"), "Postposé" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Statuts",
                keyColumn: "StatutId",
                keyValue: new Guid("a9af7b59-2326-4b38-b214-7cf8bbf6d542"));
        }
    }
}

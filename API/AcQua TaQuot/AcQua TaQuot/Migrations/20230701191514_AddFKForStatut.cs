using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AcQua_TaQuot.Migrations
{
    public partial class AddFKForStatut : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "StatutId",
                table: "TypesTache",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "StatutId",
                table: "Modules",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "StatutId",
                table: "Commanditaires",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "StatutId",
                table: "Applications",
                type: "uniqueidentifier",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StatutId",
                table: "TypesTache");

            migrationBuilder.DropColumn(
                name: "StatutId",
                table: "Modules");

            migrationBuilder.DropColumn(
                name: "StatutId",
                table: "Commanditaires");

            migrationBuilder.DropColumn(
                name: "StatutId",
                table: "Applications");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AcQua_TaQuot.Migrations
{
    public partial class Seeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Statuts",
                columns: new[] { "StatutId", "Libelle" },
                values: new object[,]
                {
                    { new Guid("8eac10f0-6285-4bce-9d0b-06a4d4311139"), "Investissement" },
                    { new Guid("cbeef23e-18a5-4041-afa4-24bded1d75ea"), "Non Facturable" },
                    { new Guid("e862834b-9b38-4db9-89eb-8ce3e0c2a3b8"), "Facturé" },
                    { new Guid("f8cc4879-f758-41eb-a250-0cf27d07dc56"), "A Facturé" }
                });

            migrationBuilder.InsertData(
                table: "TypesTache",
                columns: new[] { "TypeTacheId", "Libelle" },
                values: new object[,]
                {
                    { new Guid("012389bf-4f27-4a4d-9a1e-d3913b4050cb"), "Bug" },
                    { new Guid("18147454-9613-4996-930c-c184711afd6b"), "Congé" },
                    { new Guid("2283d1b3-e167-46c3-975d-40609cb94add"), "Régie" },
                    { new Guid("22f58d80-fca1-439e-8556-2b11c3295adc"), "Coaching" },
                    { new Guid("289a06d8-2c25-45b1-8a13-b3f9d9f222fc"), "Design" },
                    { new Guid("561f2249-8a05-4e3a-85dc-2008ff42fec8"), "Dev Interne" },
                    { new Guid("5f37688d-85d9-426e-9a9d-2d1be9177ade"), "Non productif" },
                    { new Guid("729df3e7-9206-4d59-ade3-661d961f05d6"), "Non Productif" },
                    { new Guid("9324f79f-3134-40ef-b21e-495ab88eb2a1"), "Formation" },
                    { new Guid("972f6d64-8846-460d-b8c2-18df3542c1fa"), "Documentation" },
                    { new Guid("99f8c0a9-f95b-490f-8125-1497db139654"), "Testing" },
                    { new Guid("9f6eb790-3667-4196-80be-1c577fef41d4"), "Auto-Formation" },
                    { new Guid("aab82404-4467-42c7-b369-830c606b1964"), "Maintenance" },
                    { new Guid("c1e527a4-eb03-4d5b-81a9-c4f87d337e5f"), "Absence" },
                    { new Guid("cc4c75d0-b0ae-4232-8450-9b8bed6b26dd"), "Analyse" },
                    { new Guid("ccc501fb-5b13-4332-bbd6-49883c35d672"), "Développement" },
                    { new Guid("e5994106-83d1-4a17-905d-917626a3acb9"), "Gestion Projet" },
                    { new Guid("eee98499-429d-415b-8f1d-24f15d75317f"), "Déploiement" },
                    { new Guid("f431d969-1d80-4028-9e7e-a7bbe0ae7174"), "R&D" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Statuts",
                keyColumn: "StatutId",
                keyValue: new Guid("8eac10f0-6285-4bce-9d0b-06a4d4311139"));

            migrationBuilder.DeleteData(
                table: "Statuts",
                keyColumn: "StatutId",
                keyValue: new Guid("cbeef23e-18a5-4041-afa4-24bded1d75ea"));

            migrationBuilder.DeleteData(
                table: "Statuts",
                keyColumn: "StatutId",
                keyValue: new Guid("e862834b-9b38-4db9-89eb-8ce3e0c2a3b8"));

            migrationBuilder.DeleteData(
                table: "Statuts",
                keyColumn: "StatutId",
                keyValue: new Guid("f8cc4879-f758-41eb-a250-0cf27d07dc56"));

            migrationBuilder.DeleteData(
                table: "TypesTache",
                keyColumn: "TypeTacheId",
                keyValue: new Guid("012389bf-4f27-4a4d-9a1e-d3913b4050cb"));

            migrationBuilder.DeleteData(
                table: "TypesTache",
                keyColumn: "TypeTacheId",
                keyValue: new Guid("18147454-9613-4996-930c-c184711afd6b"));

            migrationBuilder.DeleteData(
                table: "TypesTache",
                keyColumn: "TypeTacheId",
                keyValue: new Guid("2283d1b3-e167-46c3-975d-40609cb94add"));

            migrationBuilder.DeleteData(
                table: "TypesTache",
                keyColumn: "TypeTacheId",
                keyValue: new Guid("22f58d80-fca1-439e-8556-2b11c3295adc"));

            migrationBuilder.DeleteData(
                table: "TypesTache",
                keyColumn: "TypeTacheId",
                keyValue: new Guid("289a06d8-2c25-45b1-8a13-b3f9d9f222fc"));

            migrationBuilder.DeleteData(
                table: "TypesTache",
                keyColumn: "TypeTacheId",
                keyValue: new Guid("561f2249-8a05-4e3a-85dc-2008ff42fec8"));

            migrationBuilder.DeleteData(
                table: "TypesTache",
                keyColumn: "TypeTacheId",
                keyValue: new Guid("5f37688d-85d9-426e-9a9d-2d1be9177ade"));

            migrationBuilder.DeleteData(
                table: "TypesTache",
                keyColumn: "TypeTacheId",
                keyValue: new Guid("729df3e7-9206-4d59-ade3-661d961f05d6"));

            migrationBuilder.DeleteData(
                table: "TypesTache",
                keyColumn: "TypeTacheId",
                keyValue: new Guid("9324f79f-3134-40ef-b21e-495ab88eb2a1"));

            migrationBuilder.DeleteData(
                table: "TypesTache",
                keyColumn: "TypeTacheId",
                keyValue: new Guid("972f6d64-8846-460d-b8c2-18df3542c1fa"));

            migrationBuilder.DeleteData(
                table: "TypesTache",
                keyColumn: "TypeTacheId",
                keyValue: new Guid("99f8c0a9-f95b-490f-8125-1497db139654"));

            migrationBuilder.DeleteData(
                table: "TypesTache",
                keyColumn: "TypeTacheId",
                keyValue: new Guid("9f6eb790-3667-4196-80be-1c577fef41d4"));

            migrationBuilder.DeleteData(
                table: "TypesTache",
                keyColumn: "TypeTacheId",
                keyValue: new Guid("aab82404-4467-42c7-b369-830c606b1964"));

            migrationBuilder.DeleteData(
                table: "TypesTache",
                keyColumn: "TypeTacheId",
                keyValue: new Guid("c1e527a4-eb03-4d5b-81a9-c4f87d337e5f"));

            migrationBuilder.DeleteData(
                table: "TypesTache",
                keyColumn: "TypeTacheId",
                keyValue: new Guid("cc4c75d0-b0ae-4232-8450-9b8bed6b26dd"));

            migrationBuilder.DeleteData(
                table: "TypesTache",
                keyColumn: "TypeTacheId",
                keyValue: new Guid("ccc501fb-5b13-4332-bbd6-49883c35d672"));

            migrationBuilder.DeleteData(
                table: "TypesTache",
                keyColumn: "TypeTacheId",
                keyValue: new Guid("e5994106-83d1-4a17-905d-917626a3acb9"));

            migrationBuilder.DeleteData(
                table: "TypesTache",
                keyColumn: "TypeTacheId",
                keyValue: new Guid("eee98499-429d-415b-8f1d-24f15d75317f"));

            migrationBuilder.DeleteData(
                table: "TypesTache",
                keyColumn: "TypeTacheId",
                keyValue: new Guid("f431d969-1d80-4028-9e7e-a7bbe0ae7174"));
        }
    }
}

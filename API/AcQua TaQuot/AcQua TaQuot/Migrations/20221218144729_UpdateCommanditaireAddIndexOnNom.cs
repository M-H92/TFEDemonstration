using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AcQua_TaQuot.Migrations
{
    public partial class UpdateCommanditaireAddIndexOnNom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "Nom",
                table: "Commanditaires",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Statuts",
                columns: new[] { "StatutId", "Libelle" },
                values: new object[,]
                {
                    { new Guid("08929527-2bc5-4e35-88ae-d17b95d43add"), "Facturé" },
                    { new Guid("6cf661d0-3717-4fbd-bd1d-1a74a579b869"), "Investissement" },
                    { new Guid("a6209f00-e501-4a7c-9cbb-8ff410e9fbf7"), "A Facturé" },
                    { new Guid("e4ba9b11-0028-4d53-9dc0-6e63efa28504"), "Non Facturable" }
                });

            migrationBuilder.InsertData(
                table: "TypesTache",
                columns: new[] { "TypeTacheId", "Libelle" },
                values: new object[,]
                {
                    { new Guid("01d9cea9-97de-4c8e-9474-1d1dd76bb4ab"), "Congé" },
                    { new Guid("04cd697c-8e14-4c60-b03d-110f2aefb3ed"), "Testing" },
                    { new Guid("369a30bf-79e0-48b5-b31e-0527b17c10fc"), "R&D" },
                    { new Guid("3cc6b250-0cf7-4c23-ab98-78602676e2cb"), "Non productif" },
                    { new Guid("6ca33323-3410-4517-979f-2ccfad5b9e16"), "Documentation" },
                    { new Guid("89d86ec1-b947-41c1-9eaf-d9a4c6fe524b"), "Absence" },
                    { new Guid("945174c2-dd3a-4097-98f1-05c5a0c9e6b4"), "Maintenance" },
                    { new Guid("a25857a9-605b-4aef-93a0-16da8461e4ca"), "Développement" },
                    { new Guid("b5d01b18-655e-4403-9ea3-045f4b8d58a3"), "Non Productif" },
                    { new Guid("bacf01d7-9185-403f-b8e1-6247da8fc229"), "Design" },
                    { new Guid("ccd7637c-24c9-482f-92af-e9a68a71eebd"), "Gestion Projet" },
                    { new Guid("d23a49f5-c4dd-4f22-8401-6368fcafc5b3"), "Formation" },
                    { new Guid("d6a0837a-ccdb-417f-b212-c15047ad0930"), "Dev Interne" },
                    { new Guid("dc30248c-4f53-4cd3-9c89-6a2ba3504d51"), "Déploiement" },
                    { new Guid("df5243a9-d2aa-461b-aaea-eaa25ea721c9"), "Analyse" },
                    { new Guid("e0287c1a-ce72-4f78-98e6-3f7fc22bc0bf"), "Auto-Formation" },
                    { new Guid("e3be3827-62d6-4043-ade6-546bbc1589fc"), "Coaching" },
                    { new Guid("e9e344a9-b647-412c-8618-13da227f3740"), "Régie" },
                    { new Guid("ec6a3834-bf46-40f2-b2f0-ce01834de8cc"), "Bug" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Commanditaires_Nom",
                table: "Commanditaires",
                column: "Nom",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Commanditaires_Nom",
                table: "Commanditaires");

            migrationBuilder.DeleteData(
                table: "Statuts",
                keyColumn: "StatutId",
                keyValue: new Guid("08929527-2bc5-4e35-88ae-d17b95d43add"));

            migrationBuilder.DeleteData(
                table: "Statuts",
                keyColumn: "StatutId",
                keyValue: new Guid("6cf661d0-3717-4fbd-bd1d-1a74a579b869"));

            migrationBuilder.DeleteData(
                table: "Statuts",
                keyColumn: "StatutId",
                keyValue: new Guid("a6209f00-e501-4a7c-9cbb-8ff410e9fbf7"));

            migrationBuilder.DeleteData(
                table: "Statuts",
                keyColumn: "StatutId",
                keyValue: new Guid("e4ba9b11-0028-4d53-9dc0-6e63efa28504"));

            migrationBuilder.DeleteData(
                table: "TypesTache",
                keyColumn: "TypeTacheId",
                keyValue: new Guid("01d9cea9-97de-4c8e-9474-1d1dd76bb4ab"));

            migrationBuilder.DeleteData(
                table: "TypesTache",
                keyColumn: "TypeTacheId",
                keyValue: new Guid("04cd697c-8e14-4c60-b03d-110f2aefb3ed"));

            migrationBuilder.DeleteData(
                table: "TypesTache",
                keyColumn: "TypeTacheId",
                keyValue: new Guid("369a30bf-79e0-48b5-b31e-0527b17c10fc"));

            migrationBuilder.DeleteData(
                table: "TypesTache",
                keyColumn: "TypeTacheId",
                keyValue: new Guid("3cc6b250-0cf7-4c23-ab98-78602676e2cb"));

            migrationBuilder.DeleteData(
                table: "TypesTache",
                keyColumn: "TypeTacheId",
                keyValue: new Guid("6ca33323-3410-4517-979f-2ccfad5b9e16"));

            migrationBuilder.DeleteData(
                table: "TypesTache",
                keyColumn: "TypeTacheId",
                keyValue: new Guid("89d86ec1-b947-41c1-9eaf-d9a4c6fe524b"));

            migrationBuilder.DeleteData(
                table: "TypesTache",
                keyColumn: "TypeTacheId",
                keyValue: new Guid("945174c2-dd3a-4097-98f1-05c5a0c9e6b4"));

            migrationBuilder.DeleteData(
                table: "TypesTache",
                keyColumn: "TypeTacheId",
                keyValue: new Guid("a25857a9-605b-4aef-93a0-16da8461e4ca"));

            migrationBuilder.DeleteData(
                table: "TypesTache",
                keyColumn: "TypeTacheId",
                keyValue: new Guid("b5d01b18-655e-4403-9ea3-045f4b8d58a3"));

            migrationBuilder.DeleteData(
                table: "TypesTache",
                keyColumn: "TypeTacheId",
                keyValue: new Guid("bacf01d7-9185-403f-b8e1-6247da8fc229"));

            migrationBuilder.DeleteData(
                table: "TypesTache",
                keyColumn: "TypeTacheId",
                keyValue: new Guid("ccd7637c-24c9-482f-92af-e9a68a71eebd"));

            migrationBuilder.DeleteData(
                table: "TypesTache",
                keyColumn: "TypeTacheId",
                keyValue: new Guid("d23a49f5-c4dd-4f22-8401-6368fcafc5b3"));

            migrationBuilder.DeleteData(
                table: "TypesTache",
                keyColumn: "TypeTacheId",
                keyValue: new Guid("d6a0837a-ccdb-417f-b212-c15047ad0930"));

            migrationBuilder.DeleteData(
                table: "TypesTache",
                keyColumn: "TypeTacheId",
                keyValue: new Guid("dc30248c-4f53-4cd3-9c89-6a2ba3504d51"));

            migrationBuilder.DeleteData(
                table: "TypesTache",
                keyColumn: "TypeTacheId",
                keyValue: new Guid("df5243a9-d2aa-461b-aaea-eaa25ea721c9"));

            migrationBuilder.DeleteData(
                table: "TypesTache",
                keyColumn: "TypeTacheId",
                keyValue: new Guid("e0287c1a-ce72-4f78-98e6-3f7fc22bc0bf"));

            migrationBuilder.DeleteData(
                table: "TypesTache",
                keyColumn: "TypeTacheId",
                keyValue: new Guid("e3be3827-62d6-4043-ade6-546bbc1589fc"));

            migrationBuilder.DeleteData(
                table: "TypesTache",
                keyColumn: "TypeTacheId",
                keyValue: new Guid("e9e344a9-b647-412c-8618-13da227f3740"));

            migrationBuilder.DeleteData(
                table: "TypesTache",
                keyColumn: "TypeTacheId",
                keyValue: new Guid("ec6a3834-bf46-40f2-b2f0-ce01834de8cc"));

            migrationBuilder.AlterColumn<string>(
                name: "Nom",
                table: "Commanditaires",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

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
    }
}

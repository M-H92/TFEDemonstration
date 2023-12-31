﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repository;

#nullable disable

namespace AcQua_TaQuot.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    [Migration("20230331115723_UpdateTablePrestationAjoutDisplayNumber")]
    partial class UpdateTablePrestationAjoutDisplayNumber
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Entities.Models.Application", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ApplicationId");

                    b.Property<Guid>("CommanditaireId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Libelle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CommanditaireId");

                    b.ToTable("Applications");
                });

            modelBuilder.Entity("Entities.Models.Commanditaire", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("CommanditaireId");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Nom")
                        .IsUnique();

                    b.ToTable("Commanditaires");
                });

            modelBuilder.Entity("Entities.Models.LigneFacture", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("LigneFactureId");

                    b.Property<int>("MoisFacturation")
                        .HasColumnType("int");

                    b.Property<Guid>("PrestationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("PrixUnitaire")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Quantite")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("PrestationId");

                    b.ToTable("LignesFacture");
                });

            modelBuilder.Entity("Entities.Models.Module", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ModuleId");

                    b.Property<Guid>("ApplicationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Libelle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationId");

                    b.ToTable("Modules");
                });

            modelBuilder.Entity("Entities.Models.Prestation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("PrestationId");

                    b.Property<string>("Commentaire")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DisplayNumber")
                        .HasColumnType("int");

                    b.Property<bool>("IsFacturable")
                        .HasColumnType("bit");

                    b.Property<int>("IssueGitLab")
                        .HasColumnType("int");

                    b.Property<Guid>("StatutId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Temps")
                        .HasColumnType("int");

                    b.Property<Guid>("TypeTacheId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Utilisateur")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.HasKey("Id");

                    b.HasIndex("StatutId");

                    b.HasIndex("TypeTacheId");

                    b.ToTable("Prestations");
                });

            modelBuilder.Entity("Entities.Models.Prix", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("PrixId");

                    b.Property<Guid>("CommanditaireId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateDebut")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("TauxTVA")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Valeur")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CommanditaireId");

                    b.ToTable("Prices");
                });

            modelBuilder.Entity("Entities.Models.Statut", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("StatutId");

                    b.Property<string>("Libelle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Statuts");

                    b.HasData(
                        new
                        {
                            Id = new Guid("b5f8fa4f-af89-4471-afb2-55d98eb61629"),
                            Libelle = "Facturé"
                        },
                        new
                        {
                            Id = new Guid("4cfe1b05-a5dc-4c46-b9bc-288835116c0c"),
                            Libelle = "Non Facturable"
                        },
                        new
                        {
                            Id = new Guid("a6209f00-e501-4a7c-9cbb-8ff410e9fbf7"),
                            Libelle = "A Facturer"
                        },
                        new
                        {
                            Id = new Guid("6cf661d0-3717-4fbd-bd1d-1a74a579b869"),
                            Libelle = "Investissement"
                        });
                });

            modelBuilder.Entity("Entities.Models.Tache", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("TacheId");

                    b.Property<string>("Libelle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ModuleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PrestationId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ModuleId");

                    b.HasIndex("PrestationId")
                        .IsUnique();

                    b.ToTable("Taches");
                });

            modelBuilder.Entity("Entities.Models.TypeTache", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("TypeTacheId");

                    b.Property<string>("Libelle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TypesTache");

                    b.HasData(
                        new
                        {
                            Id = new Guid("0da42bd1-d8bb-4e14-a2ae-92c0de694e14"),
                            Libelle = "Non productif"
                        },
                        new
                        {
                            Id = new Guid("7421737d-7d6b-4417-a2bc-295a7f2caa86"),
                            Libelle = "Congé"
                        },
                        new
                        {
                            Id = new Guid("de71a8f3-7f1f-4103-86bf-1b86c498f8ce"),
                            Libelle = "Analyse"
                        },
                        new
                        {
                            Id = new Guid("abb535d0-6bf1-448b-b174-6929289b4109"),
                            Libelle = "Auto-Formation"
                        },
                        new
                        {
                            Id = new Guid("dca02d39-339e-4c86-b715-1194346558ba"),
                            Libelle = "Bug"
                        },
                        new
                        {
                            Id = new Guid("d5695ece-ef45-4cfa-87fd-d21544b02c0c"),
                            Libelle = "Coaching"
                        },
                        new
                        {
                            Id = new Guid("46d22b48-e878-41ca-be48-754672656a72"),
                            Libelle = "Déploiement"
                        },
                        new
                        {
                            Id = new Guid("f617ed26-acb7-4b81-9842-787409508c75"),
                            Libelle = "Développement"
                        },
                        new
                        {
                            Id = new Guid("166f80fc-7b02-448c-ace9-57355d8415f8"),
                            Libelle = "Documentation"
                        },
                        new
                        {
                            Id = new Guid("0af1d645-0b3c-4126-b1ff-fa8f0ffb1c4c"),
                            Libelle = "Formation"
                        },
                        new
                        {
                            Id = new Guid("ae0ded55-1f64-44d3-babd-9193fe0e1dc8"),
                            Libelle = "Gestion Projet"
                        },
                        new
                        {
                            Id = new Guid("df490f9f-9988-400f-ae11-89eefe5a38b8"),
                            Libelle = "R&D"
                        },
                        new
                        {
                            Id = new Guid("e7564bcd-5b63-45c8-88be-017b40863b3a"),
                            Libelle = "Régie"
                        },
                        new
                        {
                            Id = new Guid("990e4759-e41e-49cc-bf7a-d737bc507244"),
                            Libelle = "Non Productif"
                        },
                        new
                        {
                            Id = new Guid("971a9bde-fdff-4131-8871-6357c3f21af4"),
                            Libelle = "Testing"
                        },
                        new
                        {
                            Id = new Guid("6afdd5b0-fcb8-4504-94c4-04f0593ee330"),
                            Libelle = "Dev Interne"
                        },
                        new
                        {
                            Id = new Guid("aa9bc2a5-2ade-4464-9475-5dbba7457db5"),
                            Libelle = "Maintenance"
                        },
                        new
                        {
                            Id = new Guid("1fce3b1e-1b2f-440b-9181-cb78523dd609"),
                            Libelle = "Absence"
                        },
                        new
                        {
                            Id = new Guid("a1fdc591-2411-4626-9fc3-d08fc7f8345a"),
                            Libelle = "Design"
                        });
                });

            modelBuilder.Entity("Entities.Models.Application", b =>
                {
                    b.HasOne("Entities.Models.Commanditaire", "Commanditaire")
                        .WithMany("Applications")
                        .HasForeignKey("CommanditaireId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Commanditaire");
                });

            modelBuilder.Entity("Entities.Models.LigneFacture", b =>
                {
                    b.HasOne("Entities.Models.Prestation", "Prestation")
                        .WithMany("LignesFacture")
                        .HasForeignKey("PrestationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Prestation");
                });

            modelBuilder.Entity("Entities.Models.Module", b =>
                {
                    b.HasOne("Entities.Models.Application", "Application")
                        .WithMany("Modules")
                        .HasForeignKey("ApplicationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Application");
                });

            modelBuilder.Entity("Entities.Models.Prestation", b =>
                {
                    b.HasOne("Entities.Models.Statut", "Statut")
                        .WithMany("Prestations")
                        .HasForeignKey("StatutId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Models.TypeTache", "TypeTache")
                        .WithMany("Prestations")
                        .HasForeignKey("TypeTacheId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Statut");

                    b.Navigation("TypeTache");
                });

            modelBuilder.Entity("Entities.Models.Prix", b =>
                {
                    b.HasOne("Entities.Models.Commanditaire", "Commanditaire")
                        .WithMany("Prices")
                        .HasForeignKey("CommanditaireId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Commanditaire");
                });

            modelBuilder.Entity("Entities.Models.Tache", b =>
                {
                    b.HasOne("Entities.Models.Module", "Module")
                        .WithMany("Taches")
                        .HasForeignKey("ModuleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Models.Prestation", "Prestation")
                        .WithOne("Tache")
                        .HasForeignKey("Entities.Models.Tache", "PrestationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Module");

                    b.Navigation("Prestation");
                });

            modelBuilder.Entity("Entities.Models.Application", b =>
                {
                    b.Navigation("Modules");
                });

            modelBuilder.Entity("Entities.Models.Commanditaire", b =>
                {
                    b.Navigation("Applications");

                    b.Navigation("Prices");
                });

            modelBuilder.Entity("Entities.Models.Module", b =>
                {
                    b.Navigation("Taches");
                });

            modelBuilder.Entity("Entities.Models.Prestation", b =>
                {
                    b.Navigation("LignesFacture");

                    b.Navigation("Tache");
                });

            modelBuilder.Entity("Entities.Models.Statut", b =>
                {
                    b.Navigation("Prestations");
                });

            modelBuilder.Entity("Entities.Models.TypeTache", b =>
                {
                    b.Navigation("Prestations");
                });
#pragma warning restore 612, 618
        }
    }
}

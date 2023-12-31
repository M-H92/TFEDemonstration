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
    [Migration("20230516131959_UpdateTableRoleAddTableRoleUtilisateur")]
    partial class UpdateTableRoleAddTableRoleUtilisateur
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

            modelBuilder.Entity("Entities.Models.Role", b =>
                {
                    b.Property<string>("Label")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("RoleId");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Label");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Label = "DEFAUT",
                            Description = "Rôle attribué par défaut à la création d'un utilisateur. Si il ne dispose que de ce rôle, il ne pourra accéder qu'à la page home."
                        },
                        new
                        {
                            Label = "ADMIN",
                            Description = "Permet d'accéder à toutes les fonctionnalités."
                        },
                        new
                        {
                            Label = "ENCODAGE",
                            Description = "Permet à l'utilisateur d'accéder à la page d'encodage et de créer, mettre à jour ou supprimer ses propres tâches quotidiennes."
                        },
                        new
                        {
                            Label = "NIVEAUSUP",
                            Description = "Permet à l'utilisateur de gérer le niveau supérieur des tâches quotidiennes. Par exemple, la création de commanditaires."
                        },
                        new
                        {
                            Label = "NIVEAUMOY",
                            Description = "Permet à l'utilisateur de gérer le niveau moyen des tâches quotidiennes. Par exemple, la création d'applications."
                        },
                        new
                        {
                            Label = "NIVEAUINF",
                            Description = "Permet à l'utilisateur de gérer le niveau inférieur des tâches quotidiennes. Par exemple, la création de modules."
                        },
                        new
                        {
                            Label = "RECAP",
                            Description = "Permet à l'utilisateur d'accéder à l'écran de récapitulatif hebdomadaire du temps de prestation."
                        });
                });

            modelBuilder.Entity("Entities.Models.RoleUtilisateur", b =>
                {
                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Utilisateur")
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.HasKey("RoleId", "Utilisateur");

                    b.HasIndex("RoleId");

                    b.HasIndex("Utilisateur");

                    b.ToTable("RolesUtilisateurs");

                    b.HasData(
                        new
                        {
                            RoleId = "ADMIN",
                            Utilisateur = "JGO"
                        });
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
                            Id = new Guid("310bedbf-ed39-43a8-906c-b4591db75498"),
                            Libelle = "Non productif"
                        },
                        new
                        {
                            Id = new Guid("9fcf49de-dd57-4b65-b896-613397f214ed"),
                            Libelle = "Congé"
                        },
                        new
                        {
                            Id = new Guid("dabd909e-36ca-4240-a073-98fef67dd214"),
                            Libelle = "Analyse"
                        },
                        new
                        {
                            Id = new Guid("fd00b939-2902-4750-b5ed-cd2b54ac1585"),
                            Libelle = "Auto-Formation"
                        },
                        new
                        {
                            Id = new Guid("d075200f-603e-4d4f-a8a9-e43655379c6e"),
                            Libelle = "Bug"
                        },
                        new
                        {
                            Id = new Guid("a10aee50-9219-451b-96ae-fdbfd031f215"),
                            Libelle = "Coaching"
                        },
                        new
                        {
                            Id = new Guid("d4519c5a-95c9-4ff0-b8d4-0216aba857e9"),
                            Libelle = "Déploiement"
                        },
                        new
                        {
                            Id = new Guid("bc6656b5-956e-4592-a7c6-ff667e907152"),
                            Libelle = "Développement"
                        },
                        new
                        {
                            Id = new Guid("da15e83c-47ab-4440-9e62-06c0920ba7d5"),
                            Libelle = "Documentation"
                        },
                        new
                        {
                            Id = new Guid("6a496c07-38e2-482e-9baf-17f80892ad9b"),
                            Libelle = "Formation"
                        },
                        new
                        {
                            Id = new Guid("7a19c040-11b3-4a99-b33f-ea44dfb15d78"),
                            Libelle = "Gestion Projet"
                        },
                        new
                        {
                            Id = new Guid("8d0c3e25-0cd0-4e41-9dce-30814e0b2c62"),
                            Libelle = "R&D"
                        },
                        new
                        {
                            Id = new Guid("c5db2d77-e93d-4d3c-9d37-04e3a55d4a85"),
                            Libelle = "Régie"
                        },
                        new
                        {
                            Id = new Guid("f0f184a8-54be-41a6-bc9c-69e0caf0aaad"),
                            Libelle = "Non Productif"
                        },
                        new
                        {
                            Id = new Guid("0b29258a-196d-42dc-9320-c7ecb726f6e1"),
                            Libelle = "Testing"
                        },
                        new
                        {
                            Id = new Guid("579f0f6f-5c50-47c7-a03f-c60407429545"),
                            Libelle = "Dev Interne"
                        },
                        new
                        {
                            Id = new Guid("11eadc5d-aea2-4d75-91a8-aacbe6726f68"),
                            Libelle = "Maintenance"
                        },
                        new
                        {
                            Id = new Guid("11f0e6d8-7189-49e5-ba9e-2c8312a42301"),
                            Libelle = "Absence"
                        },
                        new
                        {
                            Id = new Guid("89f0790c-fe68-467f-8f7b-78bd6405b56a"),
                            Libelle = "Design"
                        });
                });

            modelBuilder.Entity("Entities.Models.userPreferences.PreferenceEncodagePrestation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("PreferenceEncodagePrestationId");

                    b.Property<bool>("InitAtLastDate")
                        .HasColumnType("bit");

                    b.Property<bool>("ResetApplication")
                        .HasColumnType("bit");

                    b.Property<bool>("ResetCommanditaire")
                        .HasColumnType("bit");

                    b.Property<bool>("ResetModule")
                        .HasColumnType("bit");

                    b.Property<bool>("ResetTypeTache")
                        .HasColumnType("bit");

                    b.Property<bool>("TempsAsInputTypeTime")
                        .HasColumnType("bit");

                    b.Property<string>("Utilisateur")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.HasKey("Id");

                    b.HasIndex("Utilisateur");

                    b.ToTable("PreferencesEncodagePrestation");
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

            modelBuilder.Entity("Entities.Models.RoleUtilisateur", b =>
                {
                    b.HasOne("Entities.Models.Role", null)
                        .WithMany("Utilisateurs")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
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

            modelBuilder.Entity("Entities.Models.Role", b =>
                {
                    b.Navigation("Utilisateurs");
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

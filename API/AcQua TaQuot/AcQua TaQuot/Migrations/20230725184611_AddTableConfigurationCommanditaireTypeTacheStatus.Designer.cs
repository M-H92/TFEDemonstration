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
    [Migration("20230725184611_AddTableConfigurationCommanditaireTypeTacheStatus")]
    partial class AddTableConfigurationCommanditaireTypeTacheStatus
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

                    b.Property<Guid?>("StatutId")
                        .HasColumnType("uniqueidentifier");

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

                    b.Property<Guid?>("StatutId")
                        .HasColumnType("uniqueidentifier");

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

                    b.Property<Guid?>("StatutId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationId");

                    b.ToTable("Modules");
                });

            modelBuilder.Entity("Entities.Models.ParametresCommanditaireTypeTacheStatut", b =>
                {
                    b.Property<Guid>("CommanditaireId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TypeTacheId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("StatutId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CommanditaireId", "TypeTacheId");

                    b.HasIndex("StatutId");

                    b.HasIndex("TypeTacheId");

                    b.ToTable("ConfigurationCommanditaireTypeTacheStatuts");
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

                    b.Property<DateTime?>("DateFacturation")
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
                        },
                        new
                        {
                            Label = "STATS",
                            Description = "Permet à l'utilisateur d'accéder à l'écran de sprint review et de récapitulatif détaillé."
                        },
                        new
                        {
                            Label = "FACTURATION",
                            Description = "Permet à l'utilisateur d'accéder à l'écran de facturation."
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
                        },
                        new
                        {
                            Id = new Guid("a9af7b59-2326-4b38-b214-7cf8bbf6d542"),
                            Libelle = "Postposé"
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

                    b.Property<Guid?>("StatutId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("TypesTache");

                    b.HasData(
                        new
                        {
                            Id = new Guid("59b97b38-88f3-40de-b96c-596cde29a480"),
                            Libelle = "Non productif"
                        },
                        new
                        {
                            Id = new Guid("d7bd3590-ef8c-49c8-9649-eea378919fe6"),
                            Libelle = "Congé"
                        },
                        new
                        {
                            Id = new Guid("67c602d8-ee1a-4618-a834-09dcca64f2e1"),
                            Libelle = "Analyse"
                        },
                        new
                        {
                            Id = new Guid("e04f05b9-3e31-4098-8cb4-0ae52cb709f4"),
                            Libelle = "Auto-Formation"
                        },
                        new
                        {
                            Id = new Guid("ff2943e0-44b7-4100-a2a3-b6b777cd342d"),
                            Libelle = "Bug"
                        },
                        new
                        {
                            Id = new Guid("2750085d-7d8a-43ca-9f1e-a1d6e5411a49"),
                            Libelle = "Coaching"
                        },
                        new
                        {
                            Id = new Guid("a20a0439-6d20-4dfc-b828-09f2ace8edbf"),
                            Libelle = "Déploiement"
                        },
                        new
                        {
                            Id = new Guid("aade0131-6db1-465a-8dcf-4e37d32f12e1"),
                            Libelle = "Développement"
                        },
                        new
                        {
                            Id = new Guid("1bae6c0a-09a8-42d6-b17b-cbe99a9429dc"),
                            Libelle = "Documentation"
                        },
                        new
                        {
                            Id = new Guid("519f746e-8325-49ce-a4fe-8428e4441274"),
                            Libelle = "Formation"
                        },
                        new
                        {
                            Id = new Guid("afb41f90-2b2e-4c3b-b36a-930b6894bc14"),
                            Libelle = "Gestion Projet"
                        },
                        new
                        {
                            Id = new Guid("10f30d63-37c2-4567-a357-8d65b987a9ca"),
                            Libelle = "R&D"
                        },
                        new
                        {
                            Id = new Guid("7d08c19c-dbdd-47d3-b766-37e75bdd2c6b"),
                            Libelle = "Régie"
                        },
                        new
                        {
                            Id = new Guid("8951a78b-1917-4cb5-8d2e-f85ce924c374"),
                            Libelle = "Non Productif"
                        },
                        new
                        {
                            Id = new Guid("2206c11c-2b69-4c16-80ed-1e2370914376"),
                            Libelle = "Testing"
                        },
                        new
                        {
                            Id = new Guid("bec5e303-9fd3-45bc-9728-7ecc57be3d2e"),
                            Libelle = "Dev Interne"
                        },
                        new
                        {
                            Id = new Guid("d8960488-d632-4958-a98e-8f48924149d8"),
                            Libelle = "Maintenance"
                        },
                        new
                        {
                            Id = new Guid("c173250f-90c3-4270-9baa-98fa2da49102"),
                            Libelle = "Absence"
                        },
                        new
                        {
                            Id = new Guid("fafe75f5-fc4a-4fc4-bcef-6fb26220b859"),
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

            modelBuilder.Entity("Entities.Models.ParametresCommanditaireTypeTacheStatut", b =>
                {
                    b.HasOne("Entities.Models.Commanditaire", "commanditaire")
                        .WithMany()
                        .HasForeignKey("CommanditaireId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Models.Statut", "statut")
                        .WithMany()
                        .HasForeignKey("StatutId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Models.TypeTache", "typeTache")
                        .WithMany()
                        .HasForeignKey("TypeTacheId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("commanditaire");

                    b.Navigation("statut");

                    b.Navigation("typeTache");
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

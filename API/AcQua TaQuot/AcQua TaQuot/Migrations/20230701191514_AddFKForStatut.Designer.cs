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
    [Migration("20230701191514_AddFKForStatut")]
    partial class AddFKForStatut
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
                            Id = new Guid("74723a37-327d-48db-a377-4e049751fdb5"),
                            Libelle = "Non productif"
                        },
                        new
                        {
                            Id = new Guid("5ed7692e-c7af-43b6-b477-115baf5a699a"),
                            Libelle = "Congé"
                        },
                        new
                        {
                            Id = new Guid("162f494e-279a-4f62-a6a1-b50c08520924"),
                            Libelle = "Analyse"
                        },
                        new
                        {
                            Id = new Guid("ac5aef63-a3f5-41ac-9470-f58665037b01"),
                            Libelle = "Auto-Formation"
                        },
                        new
                        {
                            Id = new Guid("c044776c-320d-4deb-be23-c18f0173a402"),
                            Libelle = "Bug"
                        },
                        new
                        {
                            Id = new Guid("e3910016-8bb9-441e-91db-8baa9de97169"),
                            Libelle = "Coaching"
                        },
                        new
                        {
                            Id = new Guid("d3cc3b78-0a5a-4f98-81ed-00d4d3e9b9f5"),
                            Libelle = "Déploiement"
                        },
                        new
                        {
                            Id = new Guid("95f790c9-e311-40d5-a1df-31c37b4c6e4d"),
                            Libelle = "Développement"
                        },
                        new
                        {
                            Id = new Guid("03bf8f8a-8db0-45da-84e0-6dffdc61638a"),
                            Libelle = "Documentation"
                        },
                        new
                        {
                            Id = new Guid("9436b914-c2ca-4018-8261-d1eddaf7f806"),
                            Libelle = "Formation"
                        },
                        new
                        {
                            Id = new Guid("167d10b5-725e-4031-8cab-77cf10cc461e"),
                            Libelle = "Gestion Projet"
                        },
                        new
                        {
                            Id = new Guid("ff03b842-4ddd-45c9-a412-2adf2f8bd105"),
                            Libelle = "R&D"
                        },
                        new
                        {
                            Id = new Guid("35e80d3e-4b50-4a4c-b76d-252355bba68c"),
                            Libelle = "Régie"
                        },
                        new
                        {
                            Id = new Guid("39ee38e2-0439-4ad2-b0d6-e5c947125d9b"),
                            Libelle = "Non Productif"
                        },
                        new
                        {
                            Id = new Guid("6c3ed0ed-fa11-4f47-923b-71c85431460d"),
                            Libelle = "Testing"
                        },
                        new
                        {
                            Id = new Guid("611a24a3-db3d-4482-a0ea-f91bf69e1a9f"),
                            Libelle = "Dev Interne"
                        },
                        new
                        {
                            Id = new Guid("c6ee5c90-eb38-4c4c-a798-5837504cf76b"),
                            Libelle = "Maintenance"
                        },
                        new
                        {
                            Id = new Guid("fa78b56f-8e08-4d73-86e1-c52088e3ba6f"),
                            Libelle = "Absence"
                        },
                        new
                        {
                            Id = new Guid("ab93ba2c-93e9-4589-a4f8-fd3545a7e7b4"),
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

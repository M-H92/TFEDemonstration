using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    public class TypeTacheConfiguration : IEntityTypeConfiguration<TypeTache>
    {
        public void Configure(EntityTypeBuilder<TypeTache> builder)
        {
            builder.HasData
            (
            new TypeTache
            {
                Id = Guid.NewGuid(),
                Libelle = "Non productif"
            },
            new TypeTache
            {
                Id = Guid.NewGuid(),
                Libelle = "Congé"
            },
            new TypeTache
            {
                Id = Guid.NewGuid(),
                Libelle = "Analyse"
            },
            new TypeTache
            {
                Id = Guid.NewGuid(),
                Libelle = "Auto-Formation"
            },
            new TypeTache
            {
                Id = Guid.NewGuid(),
                Libelle = "Bug"
            },
            new TypeTache
            {
                Id = Guid.NewGuid(),
                Libelle = "Coaching"
            },
            new TypeTache
            {
                Id = Guid.NewGuid(),
                Libelle = "Déploiement"
            },
            new TypeTache
            {
                Id = Guid.NewGuid(),
                Libelle = "Développement"
            },
            new TypeTache
            {
                Id = Guid.NewGuid(),
                Libelle = "Documentation"
            },
            new TypeTache
            {
                Id = Guid.NewGuid(),
                Libelle = "Formation"
            },
            new TypeTache
            {
                Id = Guid.NewGuid(),
                Libelle = "Gestion Projet"
            },
            new TypeTache
            {
                Id = Guid.NewGuid(),
                Libelle = "R&D"
            },
            new TypeTache
            {
                Id = Guid.NewGuid(),
                Libelle = "Régie"
            },
            new TypeTache
            {
                Id = Guid.NewGuid(),
                Libelle = "Non Productif"
            },
            new TypeTache
            {
                Id = Guid.NewGuid(),
                Libelle = "Testing"
            },
            new TypeTache
            {
                Id = Guid.NewGuid(),
                Libelle = "Dev Interne"
            },
            new TypeTache
            {
                Id = Guid.NewGuid(),
                Libelle = "Maintenance"
            },
            new TypeTache
            {
                Id = Guid.NewGuid(),
                Libelle = "Absence"
            },
            new TypeTache
            {
                Id = Guid.NewGuid(),
                Libelle = "Design"
            }
            );
        }

    }
}

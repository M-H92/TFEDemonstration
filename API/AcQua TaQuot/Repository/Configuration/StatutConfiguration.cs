using Contracts.IRepositories.Constantes;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    public class StatutConfiguration : IEntityTypeConfiguration<Statut>
    {
        public void Configure(EntityTypeBuilder<Statut> builder)
        {
            builder.HasData(
                new Statut
                {
                    Id = new Guid(StatutConstantes.DefaultFacturedStatut.ToString()),
                    Libelle = "Facturé"
                },
                new Statut
                {
                    Id = new Guid(StatutConstantes.DefaultNonFacturableStatut.ToString()),
                    Libelle = "Non Facturable"
                },
                new Statut
                {
                    Id = new Guid(StatutConstantes.DefaultFacturableStatut.ToString()),
                    Libelle = "A Facturer"
                },
                new Statut
                {
                    Id = new Guid(StatutConstantes.DefaultInvestmentStatut.ToString()),
                    Libelle = "Investissement"
                },
                new Statut
                {
                    Id = new Guid(StatutConstantes.DefaultPostpose.ToString()),
                    Libelle = "Postposé"
                }
                );
        }
    }
}

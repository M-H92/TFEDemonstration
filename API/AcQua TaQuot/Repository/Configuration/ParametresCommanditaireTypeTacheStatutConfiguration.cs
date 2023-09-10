using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    public class ParametresCommanditaireTypeTacheStatutConfiguration : IEntityTypeConfiguration<ParametresCommanditaireTypeTacheStatut>
    {
        public void Configure(EntityTypeBuilder<ParametresCommanditaireTypeTacheStatut> builder)
        {
            builder.HasKey(p => new { p.CommanditaireId, p.TypeTacheId });
        }
    }
}

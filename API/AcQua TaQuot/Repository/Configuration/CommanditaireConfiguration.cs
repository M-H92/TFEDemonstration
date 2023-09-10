using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    public class CommanditaireConfiguration : IEntityTypeConfiguration<Commanditaire>
    {
        public void Configure(EntityTypeBuilder<Commanditaire> builder)
        {
            builder.HasIndex(c => c.Nom).IsUnique();
        }
    }
}

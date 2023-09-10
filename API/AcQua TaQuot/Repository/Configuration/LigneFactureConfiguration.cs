using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    public class LigneFactureConfiguration : IEntityTypeConfiguration<LigneFacture>
    {
        public void Configure(EntityTypeBuilder<LigneFacture> builder)
        {
        }
    }
}

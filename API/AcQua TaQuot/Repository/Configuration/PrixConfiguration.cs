using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    public class PrixConfiguration : IEntityTypeConfiguration<Prix>
    {
        public void Configure(EntityTypeBuilder<Prix> builder)
        {
        }
    }
}

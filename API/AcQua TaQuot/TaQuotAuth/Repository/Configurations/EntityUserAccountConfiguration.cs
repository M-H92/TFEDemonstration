using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaQuotAuth.Repository.Entities;

namespace TaQuotAuth.Repository.Configurations
{
    public class EntityUserAccountConfiguration : IEntityTypeConfiguration<EntityUserAccount>
    {
        public void Configure(EntityTypeBuilder<EntityUserAccount> builder)
        {
            builder.HasKey(u => u.Id);
            builder.HasIndex(u => u.Identifier).IsUnique();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using TaQuotAuth.Repository.Configurations;
using TaQuotAuth.Repository.Entities;

namespace TaQuotAuth.Repository
{
    public class TaQuotAuthContext : DbContext
    {
        public TaQuotAuthContext(DbContextOptions options) : base(options)
        {
            Database.Migrate();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EntityUserAccountConfiguration());
        }
        public DbSet<EntityUserAccount>? UserAccount { get; set; }
    }
}

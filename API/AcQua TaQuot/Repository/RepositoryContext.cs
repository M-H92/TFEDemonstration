using Entities.Models;
using Entities.Models.userPreferences;
using Microsoft.EntityFrameworkCore;
using Repository.Configuration;
using Repository.Configuration.UserPreferences;

namespace Repository
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        {
            Database.Migrate();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ApplicationConfiguration())
                .ApplyConfiguration(new CommanditaireConfiguration())
                .ApplyConfiguration(new LigneFactureConfiguration())
                .ApplyConfiguration(new ModuleConfiguration())
                .ApplyConfiguration(new PrestationConfiguration())
                .ApplyConfiguration(new PreferenceEncodagePrestationConfiguration())
                .ApplyConfiguration(new PrixConfiguration())
                .ApplyConfiguration(new StatutConfiguration())
                .ApplyConfiguration(new TacheConfiguration())
                .ApplyConfiguration(new TypeTacheConfiguration())
                .ApplyConfiguration(new RoleConfiguration())
                .ApplyConfiguration(new RoleUtilisateurConfiguration())
                .ApplyConfiguration(new ParametresCommanditaireTypeTacheStatutConfiguration());
        }
        public DbSet<Application>? Applications { get; set; }
        public DbSet<Commanditaire>? Commanditaires { get; set; }
        public DbSet<LigneFacture>? LignesFacture { get; set; }
        public DbSet<Module>? Modules { get; set; }
        public DbSet<Prestation>? Prestations { get; set; }
        public DbSet<PreferenceEncodagePrestation>? PreferencesEncodagePrestation { get; set; }
        public DbSet<Prix>? Prices { get; set; }
        public DbSet<Statut>? Statuts { get; set; }
        public DbSet<Tache>? Taches { get; set; }
        public DbSet<TypeTache>? TypesTache { get; set; }
        public DbSet<Role>? Roles { get; set; }
        public DbSet<RoleUtilisateur>? RolesUtilisateurs { get; set; }
        public DbSet<ParametresCommanditaireTypeTacheStatut>? ConfigurationCommanditaireTypeTacheStatuts { get; set; }
    }
}

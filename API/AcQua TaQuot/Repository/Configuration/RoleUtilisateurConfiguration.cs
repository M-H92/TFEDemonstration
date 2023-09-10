using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    internal class RoleUtilisateurConfiguration : IEntityTypeConfiguration<RoleUtilisateur>
    {
        public void Configure(EntityTypeBuilder<RoleUtilisateur> builder)
        {
            builder.HasKey(ru => new { ru.RoleId, ru.Utilisateur });
            builder.HasIndex(ru => ru.RoleId);
            builder.HasIndex(ru => ru.Utilisateur);

            builder.HasData(
                new RoleUtilisateur
                {
                    RoleId = "ADMIN",
                    Utilisateur = "JGO"
                });
        }
    }
}

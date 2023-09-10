using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    internal class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasData(
                new Role
                {
                    Label = "DEFAUT",
                    Description = "Rôle attribué par défaut à la création d'un utilisateur. Si il ne dispose que de ce rôle, il ne pourra accéder qu'à la page home."
                },
                new Role
                {
                    Label = "ADMIN",
                    Description = "Permet d'accéder à toutes les fonctionnalités."
                },
                new Role
                {
                    Label = "ENCODAGE",
                    Description = "Permet à l'utilisateur d'accéder à la page d'encodage et de créer, mettre à jour ou supprimer ses propres tâches quotidiennes."
                },
                new Role
                {
                    Label = "NIVEAUSUP",
                    Description = "Permet à l'utilisateur de gérer le niveau supérieur des tâches quotidiennes. Par exemple, la création de commanditaires."
                },
                new Role
                {
                    Label = "NIVEAUMOY",
                    Description = "Permet à l'utilisateur de gérer le niveau moyen des tâches quotidiennes. Par exemple, la création d'applications."
                },
                new Role
                {
                    Label = "NIVEAUINF",
                    Description = "Permet à l'utilisateur de gérer le niveau inférieur des tâches quotidiennes. Par exemple, la création de modules."
                },
                new Role
                {
                    Label = "RECAP",
                    Description = "Permet à l'utilisateur d'accéder à l'écran de récapitulatif hebdomadaire du temps de prestation."
                },
                new Role
                {
                    Label = "STATS",
                    Description = "Permet à l'utilisateur d'accéder à l'écran de sprint review et de récapitulatif détaillé."
                },
                new Role
                {
                    Label = "FACTURATION",
                    Description = "Permet à l'utilisateur d'accéder à l'écran de facturation."
                });
        }
    }
}

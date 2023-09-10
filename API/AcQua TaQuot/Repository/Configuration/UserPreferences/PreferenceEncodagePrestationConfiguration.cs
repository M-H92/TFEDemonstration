using Entities.Models.userPreferences;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration.UserPreferences
{
    internal class PreferenceEncodagePrestationConfiguration : IEntityTypeConfiguration<PreferenceEncodagePrestation>
    {
        public void Configure(EntityTypeBuilder<PreferenceEncodagePrestation> builder)
        {
            builder.HasIndex(p => p.Utilisateur);
        }
    }
}
using Entities.Models.userPreferences;

namespace Contracts.IRepositories.userPreferences
{
    public interface IPreferenceEncodagePrestationRepository
    {
        public PreferenceEncodagePrestation? Get(string user, bool tracking);
        public void AddOrUpdate(PreferenceEncodagePrestation entity);
    }
}

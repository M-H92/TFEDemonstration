using Contracts.IRepositories.userPreferences;
using Entities.Models.userPreferences;

namespace Repository.Repositories
{
    internal class PreferenceEncodagePrestationRepository : RepositoryBase<PreferenceEncodagePrestation>, IPreferenceEncodagePrestationRepository
    {
        public PreferenceEncodagePrestationRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        { }

        public void AddOrUpdate(PreferenceEncodagePrestation entity)
        {
            var preference = this.Get(entity.Utilisateur, tracking: false);
            if (preference is null) this.Create(entity);
            else
            {
                entity.Id = preference.Id;
                this.Update(entity);
            }
        }

        public PreferenceEncodagePrestation? Get(string user, bool tracking)
            => ReadWhere(p => p.Utilisateur.Equals(user), tracking).SingleOrDefault();
    }
}

using Contracts.IRepositories.userPreferences;

namespace Contracts.IRepositories
{
    public interface IRepositoryManager
    {
        IApplicationRepository Application { get; }
        ICommanditaireRepository Commanditaire { get; }
        ILigneFactureRepository LigneFacture { get; }
        IModuleRepository Module { get; }
        IPrestationRepository Prestation { get; }
        IPreferenceEncodagePrestationRepository PreferencesEncodagePrestation { get; }
        IPrixRepository Prix { get; }
        IStatutRepository Statut { get; }
        ITacheRepository Tache { get; }
        ITypeTacheRepository TypeTache { get; }
        IRoleRepository Role { get; }
        IRoleUtilisateurRepository RoleUtilisateur { get; }
        IParametresCommanditaireTypeTacheStatutsRepository ParametresCommanditaireTypeTacheStatuts { get; }
        void Save();
        void ClearTracking();
    }
}

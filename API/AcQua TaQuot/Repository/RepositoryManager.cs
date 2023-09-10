using Contracts.IRepositories;
using Contracts.IRepositories.userPreferences;
using Repository.Repositories;

namespace Repository
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly Lazy<IApplicationRepository> _applicationRepository;
        private readonly Lazy<ICommanditaireRepository> _commanditaireRepository;
        private readonly Lazy<ILigneFactureRepository> _ligneFactureRepository;
        private readonly Lazy<IModuleRepository> _moduleRepository;
        private readonly Lazy<IPrestationRepository> _prestationRepository;
        private readonly Lazy<IPreferenceEncodagePrestationRepository> _preferenceEncodageRepository;
        private readonly Lazy<IPrixRepository> _prixRepository;
        private readonly Lazy<IStatutRepository> _statutRepository;
        private readonly Lazy<ITacheRepository> _tacheRepository;
        private readonly Lazy<ITypeTacheRepository> _typeTacheRepository;
        private readonly Lazy<IRoleRepository> _roleRepository;
        private readonly Lazy<IRoleUtilisateurRepository> _roleUtilisateurRepository;
        private readonly Lazy<IParametresCommanditaireTypeTacheStatutsRepository> _parametresCommanditaireTypeTacheStatuts;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            this._repositoryContext = repositoryContext;

            this._applicationRepository = new Lazy<IApplicationRepository>(() => new ApplicationRepository(repositoryContext));
            this._commanditaireRepository = new Lazy<ICommanditaireRepository>(() => new CommanditaireRepository(repositoryContext));
            this._ligneFactureRepository = new Lazy<ILigneFactureRepository>(() => new LigneFactureRepository(repositoryContext));
            this._moduleRepository = new Lazy<IModuleRepository>(() => new ModuleRepository(repositoryContext));
            this._prestationRepository = new Lazy<IPrestationRepository>(() => new PrestationRepository(repositoryContext));
            this._prixRepository = new Lazy<IPrixRepository>(() => new PrixRepository(repositoryContext));
            this._statutRepository = new Lazy<IStatutRepository>(() => new StatutRepository(repositoryContext));
            this._tacheRepository = new Lazy<ITacheRepository>(() => new TacheRepository(repositoryContext));
            this._typeTacheRepository = new Lazy<ITypeTacheRepository>(() => new TypeTacheRepository(repositoryContext));
            this._preferenceEncodageRepository = new Lazy<IPreferenceEncodagePrestationRepository>(() => new PreferenceEncodagePrestationRepository(repositoryContext));
            this._roleRepository = new Lazy<IRoleRepository>(() => new RoleRepository(repositoryContext));
            this._roleUtilisateurRepository = new Lazy<IRoleUtilisateurRepository>(() => new RoleUtilisateurRepository(repositoryContext));
            this._parametresCommanditaireTypeTacheStatuts = new Lazy<IParametresCommanditaireTypeTacheStatutsRepository>(() => new ParametresCommanditaireTypeTacheStatutsRepository(repositoryContext));
        }


        public IApplicationRepository Application => this._applicationRepository.Value;
        public ICommanditaireRepository Commanditaire => this._commanditaireRepository.Value;
        public ILigneFactureRepository LigneFacture => this._ligneFactureRepository.Value;
        public IModuleRepository Module => this._moduleRepository.Value;
        public IPrestationRepository Prestation => this._prestationRepository.Value;
        public IPrixRepository Prix => this._prixRepository.Value;
        public IStatutRepository Statut => this._statutRepository.Value;
        public ITacheRepository Tache => this._tacheRepository.Value;
        public ITypeTacheRepository TypeTache => this._typeTacheRepository.Value;
        public IPreferenceEncodagePrestationRepository PreferencesEncodagePrestation => this._preferenceEncodageRepository.Value;
        public IRoleRepository Role => this._roleRepository.Value;
        public IRoleUtilisateurRepository RoleUtilisateur => this._roleUtilisateurRepository.Value;
        public IParametresCommanditaireTypeTacheStatutsRepository ParametresCommanditaireTypeTacheStatuts => this._parametresCommanditaireTypeTacheStatuts.Value;

        public void Save() => this._repositoryContext.SaveChanges();
        public void ClearTracking() => this._repositoryContext.ChangeTracker.Clear();
    }
}

using Contracts;
using Contracts.IRepositories;
using Service.Admin;
using Service.Contracts;
using Service.Contracts.Admin;

namespace Service
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IApplicationService> _applicationService;
        private readonly Lazy<ICommanditaireService> _commanditaireService;
        private readonly Lazy<ILigneFactureService> _ligneFactureService;
        private readonly Lazy<IModuleService> _moduleService;
        private readonly Lazy<IPrestationService> _prestationService;
        private readonly Lazy<IPrixService> _prixService;
        private readonly Lazy<IStatutService> _statutService;
        private readonly Lazy<ITacheService> _tacheService;
        private readonly Lazy<ITypeTacheService> _typeTacheService;
        private readonly Lazy<IRecapService> _recapService;
        private readonly Lazy<IPermissionService> _permissionService;
        private readonly Lazy<IAdminPermissionService> _adminPermissionService;
        private readonly Lazy<ISprintReviewService> _sprintReviewService;
        private readonly Lazy<IRecapitulatifDetailleService> _recapitulatifDetailleService;
        private readonly Lazy<IFacturationService> _facturationService;
        private readonly Lazy<IParametresCommanditaireTypeTacheStatutService> _parametresCommanditaireTypeTacheStatutService;

        public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager loggerManager)
        {
            this._applicationService = new Lazy<IApplicationService>(() => new ApplicationService(repositoryManager, loggerManager));
            this._commanditaireService = new Lazy<ICommanditaireService>(() => new CommanditaireService(repositoryManager, loggerManager));
            this._ligneFactureService = new Lazy<ILigneFactureService>(() => new LigneFactureService(repositoryManager, loggerManager));
            this._moduleService = new Lazy<IModuleService>(() => new ModuleService(repositoryManager, loggerManager));
            this._prestationService = new Lazy<IPrestationService>(() => new PrestationService(repositoryManager, loggerManager));
            this._prixService = new Lazy<IPrixService>(() => new PrixService(repositoryManager, loggerManager));
            this._statutService = new Lazy<IStatutService>(() => new StatutService(repositoryManager, loggerManager));
            this._tacheService = new Lazy<ITacheService>(() => new TacheService(repositoryManager, loggerManager));
            this._typeTacheService = new Lazy<ITypeTacheService>(() => new TypeTacheService(repositoryManager, loggerManager));
            this._recapService = new Lazy<IRecapService>(() => new RecapService(repositoryManager));
            this._permissionService = new Lazy<IPermissionService>(() => new PermissionService(repositoryManager));
            this._adminPermissionService = new Lazy<IAdminPermissionService>(() => new AdminPermissionService(repositoryManager));
            this._sprintReviewService = new Lazy<ISprintReviewService>(() => new SprintReviewService(repositoryManager));
            this._recapitulatifDetailleService = new Lazy<IRecapitulatifDetailleService>(() => new RecapitulatifDetailleService(repositoryManager));
            this._facturationService = new Lazy<IFacturationService>(() => new FacturationService(repositoryManager));
            this._parametresCommanditaireTypeTacheStatutService = new Lazy<IParametresCommanditaireTypeTacheStatutService>(() => new ParametresCommanditaireTypeTacheStatutService(repositoryManager));
        }

        public IApplicationService ApplicationService => this._applicationService.Value;
        public ICommanditaireService CommanditaireService => this._commanditaireService.Value;
        public ILigneFactureService LigneFactureService => this._ligneFactureService.Value;
        public IModuleService ModuleService => this._moduleService.Value;
        public IPrestationService PrestationService => this._prestationService.Value;
        public IPrixService PrixService => this._prixService.Value;
        public IStatutService StatutService => this._statutService.Value;
        public ITacheService TacheService => this._tacheService.Value;
        public ITypeTacheService TypeTacheService => this._typeTacheService.Value;
        public IRecapService RecapService => this._recapService.Value;
        public IPermissionService PermissionService => this._permissionService.Value;
        public IAdminPermissionService AdminPermissionService => this._adminPermissionService.Value;
        public ISprintReviewService SprintReviewService => this._sprintReviewService.Value;
        public IRecapitulatifDetailleService RecapitulatifDetailleService => this._recapitulatifDetailleService.Value;
        public IFacturationService FacturationService => this._facturationService.Value;
        public IParametresCommanditaireTypeTacheStatutService ParametresCommanditaireTypeTacheStatutService => this._parametresCommanditaireTypeTacheStatutService.Value;
    }
}

using Service.Contracts.Admin;

namespace Service.Contracts
{
    public interface IServiceManager
    {
        public IApplicationService ApplicationService { get; }
        public ICommanditaireService CommanditaireService { get; }
        public ILigneFactureService LigneFactureService { get; }
        public IModuleService ModuleService { get; }
        public IPrestationService PrestationService { get; }
        public IPrixService PrixService { get; }
        public IStatutService StatutService { get; }
        public ITacheService TacheService { get; }
        public ITypeTacheService TypeTacheService { get; }
        public IRecapService RecapService { get; }
        public IPermissionService PermissionService { get; }
        public IAdminPermissionService AdminPermissionService { get; }
        public ISprintReviewService SprintReviewService { get; }
        public IRecapitulatifDetailleService RecapitulatifDetailleService { get; }
        public IFacturationService FacturationService { get; }
        public IParametresCommanditaireTypeTacheStatutService ParametresCommanditaireTypeTacheStatutService { get; }
    }
}

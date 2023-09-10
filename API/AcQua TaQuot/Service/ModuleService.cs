using Contracts;
using Contracts.IRepositories;
using Service.Contracts;
using Shared.DataTransfertObject.Module;

namespace Service
{
    internal sealed class ModuleService : IModuleService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _loggerManager;

        public ModuleService(IRepositoryManager repositoryManager, ILoggerManager loggerManager)
        {
            this._repositoryManager = repositoryManager;
            this._loggerManager = loggerManager;
        }

        public IEnumerable<ModuleApplicationDTO> GetModuleApplication(bool tracking)
        {
            var entities = this._repositoryManager.Module.RealAllWithApplication(tracking);

            if (entities is null)
                throw new Exception(); //TODO utilisation d'un exception spécifique

            return entities.Select(m => new ModuleApplicationDTO(m.Id, m.Libelle, m.Application?.Id ?? Guid.Empty)).ToList();
        }

        public void PostModule(CreateModuleDTO dto)
        {
            var commanditaire = this._repositoryManager.Commanditaire.Get(dto.CommanditaireId, trackChanges: false);
            if (commanditaire is null)
                throw new Exception($"Iimpossible de récupérer le commanditaire");
            var application = this._repositoryManager.Application.Get(dto.ApplicationId, trackChanges: false);
            if (application is null)
                throw new Exception($"Iimpossible de récupérer l'application");

            this._repositoryManager.Module.Create(new() { ApplicationId = dto.ApplicationId, Libelle = dto.Libelle });
            this._repositoryManager.Save();
        }
    }
}

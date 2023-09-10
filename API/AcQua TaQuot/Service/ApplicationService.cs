using Contracts;
using Contracts.IRepositories;
using Service.Contracts;
using Shared.DataTransfertObject;

namespace Service
{
    internal sealed class ApplicationService : IApplicationService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _loggerManager;

        public ApplicationService(IRepositoryManager repositoryManager, ILoggerManager loggerManager)
        {
            this._repositoryManager = repositoryManager;
            this._loggerManager = loggerManager;
        }

        public IEnumerable<ApplicationCommanditaireDTO> GetApplicationCommanditaire(bool tranckChanges)
        {
            var entities = this._repositoryManager.Application.RealAllWithCommanditaire(tranckChanges);
            if (entities is null)
                throw new Exception(); //TODO utilisation d'un exception spécifique
            return entities.Select(a => new ApplicationCommanditaireDTO(a.Id, a.Libelle, a.Commanditaire?.Id ?? Guid.Empty)).ToList();
        }

        public void PostApplication(CreateApplicationDTO dto)
        {
            var entityCommanditaire = this._repositoryManager.Commanditaire.Get(dto.CommanditaireId, trackChanges: false);
            if (entityCommanditaire is null)
                throw new Exception("Commanditaire introuvable");
            this._repositoryManager.Application.Create(new() { CommanditaireId = dto.CommanditaireId, Libelle = dto.Libelle });
            this._repositoryManager.Save();
        }
    }
}

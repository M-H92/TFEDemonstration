using Contracts;
using Contracts.IRepositories;
using Service.Contracts;
using Shared.DataTransfertObject;

namespace Service
{
    internal sealed class StatutService : IStatutService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _loggerManager;

        public StatutService(IRepositoryManager repositoryManager, ILoggerManager loggerManager)
        {
            this._repositoryManager = repositoryManager;
            this._loggerManager = loggerManager;
        }

        public IEnumerable<StatutDTO> GetAllStatut(bool tranckChanges)
        {
            //try
            //{
            return this._repositoryManager.Statut
                .GetAllStatut(tranckChanges)
                .Select(s => new StatutDTO(s.Id, s.Libelle));
            //}
            //catch(Exception ex)
            //{
            //    this._loggerManager.LogError($"Erreur lors de l'appel de {nameof(GetAllStatut)} dans {nameof(StatutService)} : {ex.Message}");
            //    throw;
            //}

        }
    }
}

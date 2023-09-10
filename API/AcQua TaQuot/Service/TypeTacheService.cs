using Contracts;
using Contracts.IRepositories;
using Service.Contracts;
using Shared.DataTransfertObject;

namespace Service
{
    internal sealed class TypeTacheService : ITypeTacheService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _loggerManager;

        public TypeTacheService(IRepositoryManager repositoryManager, ILoggerManager loggerManager)
        {
            this._repositoryManager = repositoryManager;
            this._loggerManager = loggerManager;
        }

        public IEnumerable<TypeTacheDTO> GetAllTypeTache(bool tranckChanges)
        {
            return this._repositoryManager.TypeTache.Get(tranckChanges)
                    .Select(t => new TypeTacheDTO(t.Id, t.Libelle))
                    .ToList();
        }
    }
}

using Contracts;
using Contracts.IRepositories;
using Service.Contracts;

namespace Service
{
    internal sealed class LigneFactureService : ILigneFactureService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _loggerManager;

        public LigneFactureService(IRepositoryManager repositoryManager, ILoggerManager loggerManager)
        {
            this._repositoryManager = repositoryManager;
            this._loggerManager = loggerManager;
        }
    }
}

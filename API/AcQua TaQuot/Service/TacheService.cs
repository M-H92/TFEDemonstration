using Contracts;
using Contracts.IRepositories;
using Service.Contracts;

namespace Service
{
    internal sealed class TacheService : ITacheService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _loggerManager;

        public TacheService(IRepositoryManager repositoryManager, ILoggerManager loggerManager)
        {
            this._repositoryManager = repositoryManager;
            this._loggerManager = loggerManager;
        }
    }
}

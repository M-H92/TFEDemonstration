using Contracts;
using Contracts.IRepositories;
using Service.Contracts;

namespace Service
{
    internal sealed class PrixService : IPrixService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _loggerManager;

        public PrixService(IRepositoryManager repositoryManager, ILoggerManager loggerManager)
        {
            this._repositoryManager = repositoryManager;
            this._loggerManager = loggerManager;
        }
    }
}

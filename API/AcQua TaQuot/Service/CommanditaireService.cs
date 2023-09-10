using Contracts;
using Contracts.IRepositories;
using Entities.Exceptions;
using Entities.Mapper;
using Service.Contracts;
using Shared.DataTransfertObject;

namespace Service
{
    internal sealed class CommanditaireService : ICommanditaireService
    {
        #region ctor and services

        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _loggerManager;

        public CommanditaireService(IRepositoryManager repositoryManager, ILoggerManager loggerManager)
        {
            this._repositoryManager = repositoryManager;
            this._loggerManager = loggerManager;
        }

        #endregion

        #region Create

        public CommanditaireDTO Create(CreateCommanditaireDTO commanditaire)
        {
            var entity = commanditaire.ToEntity();

            this._repositoryManager.Commanditaire.CreateCommanditaire(entity);
            this._repositoryManager.Save();

            return entity.ToCommanditaireDTO();
        }

        #endregion

        #region Read

        public CommanditaireDTO Get(Guid id, bool trackChanges)
        {
            var entity = this._repositoryManager.Commanditaire.Get(id, trackChanges);
            if (entity is null)
                throw new CommanditaireNotFoundException(id);

            return entity.ToCommanditaireDTO();
        }
        public List<CommanditaireDTO> Get(bool trackChanges)
        {
            var entities = this._repositoryManager.Commanditaire.GetCommanditaire(trackChanges);
            if (entities is null)
                throw new CommanditaireNotFoundException();

            return entities.Select(c => c.ToCommanditaireDTO()).ToList();
        }

        #endregion



    }
}

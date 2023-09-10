using Contracts.IRepositories;
using Entities.Mapper;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransfertObject.ParametresCommanditaireTypeTacheStatut;
using System.Data;

namespace Service
{
    internal sealed class ParametresCommanditaireTypeTacheStatutService : IParametresCommanditaireTypeTacheStatutService
    {
        private readonly IRepositoryManager _repositoryManager;

        public ParametresCommanditaireTypeTacheStatutService(IRepositoryManager repositoryManager)
        {
            this._repositoryManager = repositoryManager;
        }

        public Task AddParametresCommanditaireTypeTacheStatut(ParametresCommanditaireTypeTacheStatutDTO dto)
        {
            var entity = ValidateEntityOrThrow(dto);
            ThrowIfExists(dto);

            this._repositoryManager.ParametresCommanditaireTypeTacheStatuts.Create(entity);
            this._repositoryManager.Save();
            return Task.CompletedTask;
        }

        private void ThrowIfExists(ParametresCommanditaireTypeTacheStatutDTO dto)
        {
            var entity = this._repositoryManager.ParametresCommanditaireTypeTacheStatuts.Read(dto.CommanditaireId, dto.TypeTacheId, trackChanges: false);
            if (entity is not null)
                throw new Exception("Un paramètre existe déjà pour ce commanditaire et ce type de tâche");
        }

        private void ThrowIfNull(Commanditaire commanditaire, TypeTache typeTache, Statut statut)
        {
            if (commanditaire is null) throw new Exception("Commanditaire invalide");
            if (typeTache is null) throw new Exception("Commanditaire invalide");
            if (statut is null) throw new Exception("Commanditaire invalide");
        }

        public Task DeleteParametresCommanditaireTypeTacheStatut(ParametresCommanditaireTypeTacheStatutDTO dto)
        {
            var entity = ValidateEntityOrThrow(dto);

            this._repositoryManager.ParametresCommanditaireTypeTacheStatuts.Delete(entity);
            this._repositoryManager.Save();
            return Task.CompletedTask;
        }

        public Task<List<ParametresCommanditaireTypeTacheStatutDTO>> GetParametresCommanditaireTypeTacheStatut(Guid? commanditaire, Guid? typeTache, Guid? statut, int skip, int take)
        {
            var dtos = this._repositoryManager.ParametresCommanditaireTypeTacheStatuts.ReadPaginated(commanditaire, typeTache, statut, skip, take)
                .Select(p => new ParametresCommanditaireTypeTacheStatutDTO() { CommanditaireId = p.CommanditaireId, StatutDefautId = p.StatutId, TypeTacheId = p.TypeTacheId })
                .ToList();
            return Task.FromResult(dtos);
        }

        public Task<ParametresCommanditaireTypeTacheStatutDTO?> GetParametresCommanditaireTypeTacheStatut(Guid Commanditaire, Guid TypeTache)
        {
            var entity = this._repositoryManager.ParametresCommanditaireTypeTacheStatuts.Read(Commanditaire, TypeTache, trackChanges: false);
            ParametresCommanditaireTypeTacheStatutDTO? result = entity?.ToDTO();
            return Task.FromResult(result);
        }

        public Task UpdateParametresCommanditaireTypeTacheStatut(ParametresCommanditaireTypeTacheStatutDTO dto)
        {
            var entity = ValidateEntityOrThrow(dto);

            this._repositoryManager.ParametresCommanditaireTypeTacheStatuts.Update(entity);
            this._repositoryManager.Save();
            return Task.CompletedTask;
        }

        private ParametresCommanditaireTypeTacheStatut ValidateEntityOrThrow(ParametresCommanditaireTypeTacheStatutDTO dto)
        {
            var commanditaire = this._repositoryManager.Commanditaire.Get(dto.CommanditaireId, trackChanges: false);
            var typeTache = this._repositoryManager.TypeTache.Get(dto.TypeTacheId, trackChanges: false);
            var statut = this._repositoryManager.Statut.Get(dto.StatutDefautId, trackChanges: false);
            this.ThrowIfNull(commanditaire, typeTache, statut);

            return dto.ToEntity();
        }
    }
}

using Entities.Models;

namespace Contracts.IRepositories
{
    public interface IParametresCommanditaireTypeTacheStatutsRepository
    {
        public void Create(ParametresCommanditaireTypeTacheStatut entity);
        public IQueryable<ParametresCommanditaireTypeTacheStatut> ReadAll(bool trackChanges);
        public IQueryable<ParametresCommanditaireTypeTacheStatut> ReadPaginated(Guid? commanditaire, Guid? typeTache, Guid? statut, int skip, int take);
        public ParametresCommanditaireTypeTacheStatut? Read(Guid commanditaire, Guid TypeTache, bool trackChanges);
        public void Update(ParametresCommanditaireTypeTacheStatut entity);
        public void Delete(ParametresCommanditaireTypeTacheStatut entity);

    }
}

using Contracts.IRepositories;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository.Repositories
{
    internal class ParametresCommanditaireTypeTacheStatutsRepository : RepositoryBase<ParametresCommanditaireTypeTacheStatut>, IParametresCommanditaireTypeTacheStatutsRepository
    {
        public ParametresCommanditaireTypeTacheStatutsRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        { }

        public ParametresCommanditaireTypeTacheStatut? Read(Guid commanditaire, Guid TypeTache, bool trackChanges)
            => this.ReadWhere((e) => e.CommanditaireId.Equals(commanditaire) && e.TypeTacheId.Equals(TypeTache), trackChanges)
            .Include(s => s.Statut)
            .FirstOrDefault();

        public IQueryable<ParametresCommanditaireTypeTacheStatut> ReadPaginated(Guid? commanditaire, Guid? typeTache, Guid? statut, int skip, int take)
        {
            var query = this._repositoryContext.ConfigurationCommanditaireTypeTacheStatuts.AsQueryable();

            if (commanditaire is not null)
                query = query.Where(c => c.CommanditaireId.Equals(commanditaire));
            if (typeTache is not null)
                query = query.Where(c => c.TypeTacheId.Equals(typeTache));
            if (statut is not null)
                query = query.Where(c => c.StatutId.Equals(statut));

            query.OrderBy(c => c.CommanditaireId)
                .ThenBy(c => c.TypeTacheId)
                .ThenBy(c => c.StatutId)
                .Skip(skip)
                .Take(take);

            return query;
        }
    }
}

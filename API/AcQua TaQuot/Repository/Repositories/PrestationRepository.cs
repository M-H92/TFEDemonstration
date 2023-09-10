using Contracts.IRepositories;
using Contracts.IRepositories.Constantes;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository.Repositories
{
    internal class PrestationRepository : RepositoryBase<Prestation>, IPrestationRepository
    {
        private readonly RepositoryContext _repositoryContext;

        public PrestationRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
            this._repositoryContext = repositoryContext;
        }

        public void CreatePrestation(Prestation prestation)
            => this.Create(prestation);

        new public void Delete(Prestation prestation)
         => base.Delete(prestation);
        public Prestation? GetDetails(Guid id, bool trackChanges)
            => this.ReadWhere(e => e.Id.Equals(id), trackChanges)
                .Include(e => e.Tache)
                .ThenInclude(e => e.Module)
                .ThenInclude(e => e.Application)
                .ThenInclude(e => e.Commanditaire)
                .SingleOrDefault();
        public Prestation? Get(Guid id, bool trackChanges)
            => this.ReadWhere(e => e.Id.Equals(id), trackChanges).SingleOrDefault();

        public List<Prestation> GetPrestations(int take, int skip, string user)
            => this.ReadWhere(p => p.Utilisateur.Equals(user), trackChanges: false)
                   .OrderByDescending(p => p.Date)
                   .Skip(skip)
                   .Take(take)
                   .Include(p => p.TypeTache)
                   .Include(p => p.Tache)
                   .ThenInclude(t => t.Module)
                   .ThenInclude(m => m.Application)
                   .ThenInclude(a => a.Commanditaire)
                   .ToList();
        public List<Prestation> GetPrestations(DateTime from, DateTime to)
            => this.ReadWhere(e => e.Date >= from && e.Date <= to, trackChanges: false)
                   .OrderByDescending(p => p.Date)
                   .Include(p => p.TypeTache)
                   .Include(p => p.Tache)
                   .ThenInclude(t => t.Module)
                   .ThenInclude(m => m.Application)
                   .ThenInclude(a => a.Commanditaire)
                   .ToList();

        public int GetNextDisplayNumber(DateTime datePrestation)
            => this.ReadWhere(e => e.Date == datePrestation, trackChanges: false)
                .Select(p => p.DisplayNumber)
                .Max() + 1 ?? 1;

        public List<Prestation> GetFacturable(DateTime from, DateTime to)
            => this.ReadWhere(e => e.Date >= from && e.Date <= to, trackChanges: false)
                   .OrderByDescending(p => p.Date)
                   .Include(p => p.TypeTache)
                   .Include(p => p.Tache)
                   .ThenInclude(t => t.Module)
                   .ThenInclude(m => m.Application)
                   .ThenInclude(a => a.Commanditaire)
                   .Include(p => p.Statut)
                   .Where(p => p.StatutId == StatutConstantes.DefaultFacturableStatut)
                   .ToList();
    }
}

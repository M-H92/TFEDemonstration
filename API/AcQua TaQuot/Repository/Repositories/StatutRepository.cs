using Contracts.IRepositories;
using Contracts.IRepositories.Constantes;
using Entities.Models;

namespace Repository.Repositories
{
    internal class StatutRepository : RepositoryBase<Statut>, IStatutRepository
    {

        public Guid DefaultFacturableStatut => StatutConstantes.DefaultFacturableStatut;
        public Guid DefaultNonFacturableStatut => StatutConstantes.DefaultNonFacturableStatut;
        public Guid DefaultFacturedStatut => StatutConstantes.DefaultFacturedStatut;
        public Guid DefaultInvestmentStatut => StatutConstantes.DefaultInvestmentStatut;

        public StatutRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public IEnumerable<Statut> GetAllStatut(bool trackChanges) => ReadAll(trackChanges).ToList();
        public Statut? GetDefaultFacturableStatut(bool trackChanges)
            => ReadWhere((s => s.Id.Equals(this.DefaultFacturableStatut)), trackChanges).FirstOrDefault();
        public Statut? GetDefaultNonFacturableStatut(bool trackChanges)
            => ReadWhere((s => s.Id.Equals(this.DefaultNonFacturableStatut)), trackChanges).FirstOrDefault();
        public IEnumerable<Statut> GetDefaultUntouchablesStatuts()
            => this.ReadAll(false).Where(s => s.Id.Equals(this.DefaultFacturedStatut) || s.Id.Equals(this.DefaultInvestmentStatut));
        public Statut? Get(Guid statutId, bool trackChanges)
            => this.ReadWhere((s) => s.Id.Equals(statutId), trackChanges).FirstOrDefault();
    }
}

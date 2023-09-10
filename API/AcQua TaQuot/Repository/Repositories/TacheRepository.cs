using Contracts.IRepositories;
using Entities.Models;

namespace Repository.Repositories
{
    internal class TacheRepository : RepositoryBase<Tache>, ITacheRepository
    {
        public TacheRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateTache(Tache entity) => Create(entity);

        public Tache? Get(Guid id, bool trackChanges)
            => this.ReadWhere(t => t.Id.Equals(id), trackChanges).SingleOrDefault();
    }
}

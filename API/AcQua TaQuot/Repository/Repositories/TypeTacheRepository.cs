using Contracts.IRepositories;
using Entities.Models;

namespace Repository.Repositories
{
    internal class TypeTacheRepository : RepositoryBase<TypeTache>, ITypeTacheRepository
    {
        public TypeTacheRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
        public TypeTache Get(Guid typeTacheId, bool trackChanges)
            => ReadWhere(t => t.Id.Equals(typeTacheId), trackChanges).FirstOrDefault();

        public List<TypeTache> Get(bool trackChanges)
            => ReadAll(trackChanges).ToList();
    }
}

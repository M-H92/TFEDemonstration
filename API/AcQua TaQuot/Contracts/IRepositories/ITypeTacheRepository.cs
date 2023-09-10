using Entities.Models;

namespace Contracts.IRepositories
{
    public interface ITypeTacheRepository
    {
        public TypeTache Get(Guid typeTacheId, bool trackChanges);
        public List<TypeTache> Get(bool trackChanges);
    }
}

using Contracts.IRepositories;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository.Repositories
{
    internal class ModuleRepository : RepositoryBase<Module>, IModuleRepository
    {
        public ModuleRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public Module? Get(Guid moduleId, bool trackChanges)
                => ReadWhere(e => e.Id.Equals(moduleId), trackChanges).SingleOrDefault();

        public IEnumerable<Module> RealAllWithApplication(bool tracking)
            => ReadAll(tracking).Include(m => m.Application).ToList();
    }
}

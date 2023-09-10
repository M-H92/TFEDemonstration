using Contracts.IRepositories;
using Entities.Models;

namespace Repository.Repositories
{
    internal class RoleRepository : RepositoryBase<Role>, IRoleRepository
    {
        public RoleRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }

        public IEnumerable<Role> GetRoles(bool tranckChanges)
            => this.ReadAll(tranckChanges);
    }
}

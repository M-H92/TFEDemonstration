using Entities.Models;

namespace Contracts.IRepositories
{
    public interface IRoleRepository
    {
        public IEnumerable<Role> GetRoles(bool tranckChanges);
    }
}

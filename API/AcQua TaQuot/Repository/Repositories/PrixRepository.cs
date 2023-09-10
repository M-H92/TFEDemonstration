using Contracts.IRepositories;
using Entities.Models;

namespace Repository.Repositories
{
    internal class PrixRepository : RepositoryBase<Prix>, IPrixRepository
    {
        public PrixRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}

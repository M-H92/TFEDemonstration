using Contracts.IRepositories;
using Entities.Models;

namespace Repository.Repositories
{
    internal class LigneFactureRepository : RepositoryBase<LigneFacture>, ILigneFactureRepository
    {
        public LigneFactureRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}

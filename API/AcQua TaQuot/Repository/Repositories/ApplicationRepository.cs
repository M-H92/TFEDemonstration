using Contracts.IRepositories;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository.Repositories
{
    internal class ApplicationRepository : RepositoryBase<Application>, IApplicationRepository
    {
        public ApplicationRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public Application? Get(Guid applicationId, bool trackChanges)
            => ReadWhere(a => a.Id.Equals(applicationId), trackChanges).SingleOrDefault();

        public List<Application> RealAllWithCommanditaire(bool trackChanges)
            => ReadAll(trackChanges).Include(a => a.Commanditaire).ToList();
    }
}

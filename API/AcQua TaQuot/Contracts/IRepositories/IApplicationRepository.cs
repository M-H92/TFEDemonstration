using Entities.Models;

namespace Contracts.IRepositories
{
    public interface IApplicationRepository
    {
        public Application? Get(Guid applicationId, bool trackChanges);
        public List<Application> RealAllWithCommanditaire(bool trackChanges);
        public void Create(Application application);
    }
}

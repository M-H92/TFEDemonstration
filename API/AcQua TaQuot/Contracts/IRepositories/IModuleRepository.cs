using Entities.Models;

namespace Contracts.IRepositories
{
    public interface IModuleRepository
    {
        public Module? Get(Guid moduleId, bool trackChanges);
        IEnumerable<Module> RealAllWithApplication(bool tracking);
        void Create(Module module);
    }
}

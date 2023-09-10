using Contracts.IRepositories;
using Entities.Models;

namespace Repository.Repositories
{
    internal class CommanditaireRepository : RepositoryBase<Commanditaire>, ICommanditaireRepository
    {
        public CommanditaireRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public Commanditaire? Get(Guid commanditaireId, bool trackChanges)
            => ReadWhere(c => c.Id.Equals(commanditaireId), trackChanges).SingleOrDefault();

        public List<Commanditaire> GetCommanditaire(bool trackChanges)
            => ReadAll(trackChanges).ToList();

        public void CreateCommanditaire(Commanditaire entity)
            => Create(entity);

    }
}

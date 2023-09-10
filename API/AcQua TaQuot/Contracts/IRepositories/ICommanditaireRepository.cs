using Entities.Models;

namespace Contracts.IRepositories
{
    public interface ICommanditaireRepository
    {
        Commanditaire Get(Guid commanditaireId, bool trackChanges);
        List<Commanditaire> GetCommanditaire(bool trackChanges);
        void CreateCommanditaire(Commanditaire entity);
    }
}

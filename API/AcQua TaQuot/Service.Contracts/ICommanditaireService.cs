using Shared.DataTransfertObject;

namespace Service.Contracts
{
    public interface ICommanditaireService
    {
        CommanditaireDTO Get(Guid id, bool trackChanges);
        List<CommanditaireDTO> Get(bool trackChanges);
        CommanditaireDTO Create(CreateCommanditaireDTO commanditaire);
    }
}

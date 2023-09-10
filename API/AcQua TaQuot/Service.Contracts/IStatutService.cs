using Shared.DataTransfertObject;

namespace Service.Contracts
{
    public interface IStatutService
    {
        IEnumerable<StatutDTO> GetAllStatut(bool tranckChanges);
    }
}

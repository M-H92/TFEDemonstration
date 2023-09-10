using Shared.DataTransfertObject;

namespace Service.Contracts
{
    public interface ITypeTacheService
    {
        IEnumerable<TypeTacheDTO> GetAllTypeTache(bool tranckChanges);
    }
}

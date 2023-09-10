using Shared.DataTransfertObject.Module;

namespace Service.Contracts
{
    public interface IModuleService
    {
        IEnumerable<ModuleApplicationDTO> GetModuleApplication(bool tracking);
        void PostModule(CreateModuleDTO dto);
    }
}

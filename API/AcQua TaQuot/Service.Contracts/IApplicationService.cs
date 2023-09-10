using Shared.DataTransfertObject;

namespace Service.Contracts
{
    public interface IApplicationService
    {
        IEnumerable<ApplicationCommanditaireDTO> GetApplicationCommanditaire(bool tranckChanges);
        void PostApplication(CreateApplicationDTO dto);

    }
}

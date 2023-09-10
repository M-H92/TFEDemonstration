namespace Shared.DataTransfertObject.Module
{
    public record ModuleApplicationDTO(Guid id, string libelle, Guid ApplicationId);
    public record CreateModuleDTO(string Libelle, Guid ApplicationId, Guid CommanditaireId);
}

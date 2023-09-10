namespace Shared.DataTransfertObject
{
    public record CreatePrestationDTO(
        string? Commentaire,
        string Tache,
        DateTime Date,
        int Temps,
        string Utilisateur,
        Guid TypeTacheId,
        Guid CommanditaireId,
        Guid ApplicationId,
        Guid ModuleId);
}

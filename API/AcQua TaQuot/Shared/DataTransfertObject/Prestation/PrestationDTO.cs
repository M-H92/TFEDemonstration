namespace Shared.DataTransfertObject
{
    public record PrestationDTO(
        Guid Id,
        int IssueGitLab,
        string Commentaire,
        DateTime Date,
        int Temps,
        bool IsFacturable,
        string Utilisateur,
        Guid TypeTacheId,
        Guid StatutId);

    public record DetailPrestationDTO(
        Guid Id,
        DateTime Date,
        int Temps,
        Guid TypeTacheId,
        Guid CommanditaireId,
        Guid ApplicationId,
        Guid ModuleId,
        Guid TacheId,
        string Tache,
        string Commentaire);

    public record UpdatePrestationDTO(
        string Commentaire,
        string Tache,
        DateTime Date,
        int Temps,
        Guid TypeTacheId);
}

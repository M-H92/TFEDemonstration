namespace Shared.DataTransfertObject
{
    public record CreateTaQuotDTO(DateTime Date,
                                  Guid CommanditaireId,
                                  Guid ApplicationId,
                                  Guid ModuleId,
                                  string Tache,
                                  string Commantaire,
                                  Guid TypeTacheId,
                                  int Temps);
}

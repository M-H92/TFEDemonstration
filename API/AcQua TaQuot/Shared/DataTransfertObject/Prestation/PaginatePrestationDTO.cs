namespace Shared.DataTransfertObject
{
    public record PaginatePrestationDTO(Guid Id,
                                        DateTime Date,
                                        int Temps,
                                        string TypeTache,
                                        string Commanditaire,
                                        string Application,
                                        string Module,
                                        string Tache,
                                        string Commentaire);


}

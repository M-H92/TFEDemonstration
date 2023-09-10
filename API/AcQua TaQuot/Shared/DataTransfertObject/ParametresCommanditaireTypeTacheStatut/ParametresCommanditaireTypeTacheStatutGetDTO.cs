namespace Shared.DataTransfertObject.ParametresCommanditaireTypeTacheStatut
{
    public class ParametresCommanditaireTypeTacheStatutGetDTO
    {
        public Guid? CommanditaireId { get; set; }
        public Guid? TypeTacheId { get; set; }
        public Guid? StatutDefautId { get; set; }
        public int Skip { get; set; } = 0;
        public int Take { get; set; } = 10;
    }
}

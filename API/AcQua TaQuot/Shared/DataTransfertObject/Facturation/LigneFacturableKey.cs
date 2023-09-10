namespace Shared.DataTransfertObject.Facturation
{
    public class LigneFacturableKey
    {
        public string Tache { get; set; }
        public Guid ModuleId { get; set; }
        public Guid TypeTacheId { get; set; }
        public Guid StatutId { get; set; }
    }
}

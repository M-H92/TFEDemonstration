namespace Shared.DataTransfertObject.Facturation
{
    public class ExportableLigneFacturableDTO
    {
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public List<LigneFacturableKey> ligneFacturableDTOs { get; set; }
    }
}

using Shared.DataTransfertObject.Facturation;

namespace Service.Contracts
{
    public interface IFacturationService
    {
        public IEnumerable<LigneFacturableDTO> GetLignesFacturables(DateTime from, DateTime to);
        public byte[] ExportFacturableToCSV(ExportableLigneFacturableDTO dto);
    }
}

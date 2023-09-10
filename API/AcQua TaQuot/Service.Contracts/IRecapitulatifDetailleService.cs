using Shared.DataTransfertObject.RecapitulatifDetaille;

namespace Service.Contracts
{
    public interface IRecapitulatifDetailleService
    {
        public IEnumerable<TypeTacheStatsDTO> GetRecapitulatifDetailleStats(int backwardsMonths = 0);
        public int GetJoursPrestes(int backwardsMonths = 0);
    }
}

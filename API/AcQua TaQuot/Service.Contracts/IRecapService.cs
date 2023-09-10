using Shared.DataTransfertObject.Recap;

namespace Service.Contracts
{
    public interface IRecapService
    {
        IEnumerable<WeeklyRecapDTO> GetWeeklyRecaps(DateTime startDate);
    }
}

using Contracts.IRepositories;
using Service.Contracts;
using Shared.DataTransfertObject.Recap;

namespace Service
{
    public class RecapService : IRecapService
    {
        private readonly IRepositoryManager _repositoryManager;

        public RecapService(IRepositoryManager repositoryManager)
        {
            this._repositoryManager = repositoryManager;
        }
        public IEnumerable<WeeklyRecapDTO> GetWeeklyRecaps(DateTime startDate)
        {
            startDate = this.SetToMonday(startDate);
            DateTime endDate = startDate.AddDays(4);
            var prestations = this._repositoryManager.Prestation.GetPrestations(startDate, endDate);
            List<WeeklyRecapDTO> recaps = new();
            foreach (var prestation in prestations)
            {
                var recap = recaps.Find(e => e.user == prestation.Utilisateur);
                if (recap is null)
                {
                    recap = new WeeklyRecapDTO(prestation.Utilisateur, new int[6]);
                    recaps.Add(recap);
                    recap.times[(int)prestation.Date.DayOfWeek - 1] = prestation.Temps;
                }
                else
                {
                    recap.times[(int)prestation.Date.DayOfWeek - 1] += prestation.Temps;
                }
            }
            foreach (var recap in recaps)
            {
                recap.times[^1] = recap.times.Sum() / 5;
            }

            return recaps;
        }

        private DateTime SetToMonday(DateTime startDate)
        {
            if (startDate.DayOfWeek is not DayOfWeek.Monday)
            {
                startDate = startDate.AddDays((int)startDate.DayOfWeek - 1);
            }

            return startDate;
        }
    }
}

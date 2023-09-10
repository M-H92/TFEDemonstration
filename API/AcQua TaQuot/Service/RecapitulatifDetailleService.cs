using Contracts.IRepositories;
using Service.Contracts;
using Shared.DataTransfertObject.RecapitulatifDetaille;
using Shared.DataTransfertObject.SprintReview;

namespace Service
{
    internal sealed class RecapitulatifDetailleService : IRecapitulatifDetailleService
    {
        private readonly IRepositoryManager _repositoryManager;

        public RecapitulatifDetailleService(IRepositoryManager repositoryManager)
        {
            this._repositoryManager = repositoryManager;
        }


        public IEnumerable<TypeTacheStatsDTO> GetRecapitulatifDetailleStats(int backwardMonths = 0)
        {
            var endDate = DateTime.Today.AddMonths(-backwardMonths);
            var startDate = new DateTime(endDate.Year, endDate.Month, 1);
            var prestations = this._repositoryManager.Prestation.GetPrestations(startDate, endDate);
            var prestationsPerTypeTache = prestations.GroupBy(p => p.TypeTache.Libelle.ToUpper());

            List<TypeTacheStatsDTO> result = new();
            foreach (var pptt in prestationsPerTypeTache)
            {
                List<CollaborateurTimeDTO> collaborateurTimeDTOs = new();
                foreach (var user in pptt.Select(p => p.Utilisateur.ToUpper()).Distinct().ToList())
                    collaborateurTimeDTOs.Add(new CollaborateurTimeDTO(user, pptt.Where(p => p.Utilisateur.ToUpper() == user).Select(p => p.Temps).Sum()));
                result.Add(new(pptt.First().TypeTache.Libelle, collaborateurTimeDTOs, collaborateurTimeDTOs.Select(c => c.SpentTime).Sum()));
            }

            var typeTachesSansPrestation = this._repositoryManager.TypeTache.Get(trackChanges: false);
            typeTachesSansPrestation = typeTachesSansPrestation.Where(t => !result.Any(r => r.Label.ToUpper() == t.Libelle.ToUpper())).ToList();
            foreach (var ttsp in typeTachesSansPrestation)
            {
                List<CollaborateurTimeDTO> collaborateurTimeDTOs = new();
                result.Add(new(ttsp.Libelle, collaborateurTimeDTOs, 0));
            }
            return result;
        }

        public int GetJoursPrestes(int backwardsMonths = 0)
        {
            var endDate = DateTime.Today.AddMonths(-backwardsMonths);
            var startDate = new DateTime(endDate.Year, endDate.Month, 1);
            var prestations = this._repositoryManager.Prestation.GetPrestations(startDate, endDate);
            return prestations.GroupBy(p => p.Date).Count();
        }
    }
}

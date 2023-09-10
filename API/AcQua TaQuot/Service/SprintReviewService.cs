using Contracts.IRepositories;
using Service.Contracts;
using Shared.DataTransfertObject.SprintReview;

namespace Service
{
    internal sealed class SprintReviewService : ISprintReviewService
    {
        private readonly IRepositoryManager _repositoryManager;

        public SprintReviewService(IRepositoryManager repositoryManager)
        {
            this._repositoryManager = repositoryManager;
        }

        public IEnumerable<SprintIssueStatsDTO> GetSprintReviewStats(List<string> collaborateurs, DateTime dateDebut, DateTime dateFin)
        {
            var prestations = this._repositoryManager.Prestation.GetPrestations(dateDebut, dateFin);
            prestations = prestations.Where(p => collaborateurs.Contains(p.Utilisateur)).ToList();
            var prestationsParTache = prestations.GroupBy(p => p.Tache?.Libelle).ToList();

            List<SprintIssueStatsDTO> result = new();
            foreach (var ppt in prestationsParTache)
            {
                List<CollaborateurTimeDTO> collaborateursTime = new();
                foreach (var user in ppt.Select(p => p.Utilisateur.ToUpper()).Distinct().ToList())
                    collaborateursTime.Add(new CollaborateurTimeDTO(user, ppt.Where(p => p.Utilisateur.ToUpper() == user).Select(p => p.Temps).Sum()));
                result.Add(new(ppt.First().Tache.Libelle, collaborateursTime, collaborateursTime.Select(c => c.SpentTime).Sum()));
            }

            return result;
        }
    }
}

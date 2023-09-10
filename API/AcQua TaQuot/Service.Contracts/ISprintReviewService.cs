using Shared.DataTransfertObject.SprintReview;

namespace Service.Contracts
{
    public interface ISprintReviewService
    {
        public IEnumerable<SprintIssueStatsDTO> GetSprintReviewStats(List<string> collaborateurs, DateTime dateDebut, DateTime dateFin);
    }
}

using Shared.DataTransfertObject.SprintReview;

namespace Shared.DataTransfertObject.RecapitulatifDetaille
{
    public record TypeTacheStatsDTO(string Label, IEnumerable<CollaborateurTimeDTO> CollaborateurTimes, int TotalTime);
}

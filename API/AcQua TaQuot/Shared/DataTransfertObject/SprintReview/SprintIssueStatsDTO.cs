namespace Shared.DataTransfertObject.SprintReview
{
    public record SprintIssueStatsDTO(string Label, IEnumerable<CollaborateurTimeDTO> CollaborateurTimes, int TotalTime);
}

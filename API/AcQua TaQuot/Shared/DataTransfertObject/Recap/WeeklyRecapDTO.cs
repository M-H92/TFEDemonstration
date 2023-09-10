namespace Shared.DataTransfertObject.Recap
{
    /// <summary>Where times is an array consisting of the sum of time per day (from Monday to Friday) for the user and an average for the week </summary>
    /// <param name="user"></param>
    /// <param name="times"></param>
    public record WeeklyRecapDTO(string user, int[] times);
}

namespace Ticketing.Entities.Dtos.Responses;

public class DriverAchievementResponse
{
    public Guid DriverId { get; set; }
    public int WorldChampionships { get; set; }
    public int FastestLap { get; set; }
    public int PolePosition { get; set; }
    public int Wins { get; set; }
}

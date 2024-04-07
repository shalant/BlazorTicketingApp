namespace Ticketing.Entities.Dtos.Requests;

public class UpdateDriverAchievementRequest
{
    public Guid DriverId { get; set; }
    public int WorldChampionships { get; set; }
    public int FastestLap { get; set; }
    public int PolePosition { get; set; }
    public int Wins { get; set; }
}

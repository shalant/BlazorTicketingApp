namespace Ticketing.Entities.Dtos.Requests;

public class CreateDriverAchievementRequest
{
    public Guid DriverId { get; set; }
    public int WorldChampionships { get; set; }
    public int FastestLap {  get; set; }
    public int PolePosition { get; set; }
    public int Wins { get; set; }
}

using Ticketing.Entities.DbSet;

namespace Ticketing.DataService.Repositories.Interfaces;

public interface IAchievementsRepository : IGenericRepository<Achievement>
{
    Task<Achievement> GetDriverAchievementsAsync(Guid driverId);
}

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Ticketing.DataService.Data;
using Ticketing.DataService.Repositories.Interfaces;
using Ticketing.Entities.DbSet;

namespace Ticketing.DataService.Repositories;

public class AchievementRepository : GenericRepository<Achievement>, IAchievementsRepository
{
    public AchievementRepository(AppDbContext context, ILogger _logger) : base(context, _logger)
    {}

    public async Task<Achievement?> GetDriverAchievementsAsync(Guid driverId)
    {
		try
		{
            return await _dbset.FirstOrDefaultAsync(x => x.DriverId == driverId);
		}
		catch (Exception e)
		{
            _logger.LogError(exception: e, message: "GetAll function error", typeof(AchievementRepository));
            throw;
        }
    }

    public override async Task<IEnumerable<Achievement>> GetAll()
    {
        try
        {
            return await _dbset.Where(x => x.Status == true)
                .AsNoTracking()
                .AsSplitQuery()
                .OrderBy(x => x.AddedDate)
                .ToListAsync();
        }
        catch (Exception e)
        {
            _logger.LogError(exception: e, message: "GetAll function error", typeof(AchievementRepository));
            throw;
        }
    }

    public override async Task<bool> Delete(Guid id)
    {
        try
        {
            //get entity
            var result = await _dbset.FirstOrDefaultAsync(x => x.Id == id);

            if (result == null)
            {
                return false;
            }
            else
            {
                result.Status = false;
                result.UpdatedDate = DateTime.UtcNow;

                return true;
            }
        }
        catch (Exception e)
        {
            _logger.LogError(exception: e, message: "Delete function error", typeof(AchievementRepository));
            throw;
        }
    }

    public override async Task<bool> Update(Achievement achievement)
    {
        try
        {
            //get entity
            var result = await _dbset.FirstOrDefaultAsync(x => x.Id == achievement.Id);

            if (result == null)
            {
                return false;
            }
            else
            {
                result.UpdatedDate = DateTime.UtcNow;
                result.FastestLap = achievement.FastestLap;
                result.PolePosition = achievement.PolePosition;
                result.RaceWins = achievement.RaceWins;
                result.WorldChampionships = achievement.WorldChampionships;
                return true;
            }
        }
        catch (Exception e)
        {
            _logger.LogError(exception: e, message: "Delete function error", typeof(AchievementRepository));
            throw;
        }
    }
}

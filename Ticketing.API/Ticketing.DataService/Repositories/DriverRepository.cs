using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Ticketing.DataService.Data;
using Ticketing.DataService.Repositories.Interfaces;
using Ticketing.Entities.DbSet;

namespace Ticketing.DataService.Repositories;

public class DriverRepository : GenericRepository<Driver>, IDriverRepository
{
    public DriverRepository(AppDbContext context, ILogger _logger) : base(context, _logger)
    {}

    public override async Task <IEnumerable<Driver>> GetAll()
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
            _logger.LogError(exception: e, message: "GetAll function error", typeof(DriverRepository));
            throw;
        }
    }

    public override async Task<bool> Delete(Guid id)
    {
        try
        {
            //get entity
            var result = await _dbset.FirstOrDefaultAsync(x => x.Id == id);

            if(result == null)
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
            _logger.LogError(exception: e, message: "Delete function error", typeof(DriverRepository));
            throw;
        }
    }

    public override async Task<bool> Update(Driver driver)
    {
        try
        {
            //get entity
            var result = await _dbset.FirstOrDefaultAsync(x => x.Id == driver.Id);

            if (result == null)
            {
                return false;
            }
            else
            {
                result.UpdatedDate = DateTime.UtcNow;
                result.DriverNumber = driver.DriverNumber;
                result.FirstName = driver.FirstName;
                result.LastName = driver.LastName;
                result.DateOfBirth = driver.DateOfBirth;
                return true;
            }
        }
        catch (Exception e)
        {
            _logger.LogError(exception: e, message: "Update function error", typeof(DriverRepository));
            throw;
        }
    }
}

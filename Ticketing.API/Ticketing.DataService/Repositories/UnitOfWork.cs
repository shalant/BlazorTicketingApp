using Microsoft.Extensions.Logging;
using Ticketing.DataService.Data;
using Ticketing.DataService.Repositories.Interfaces;

namespace Ticketing.DataService.Repositories;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly AppDbContext _context;

    public IDriverRepository Drivers { get; }
    public IAchievementsRepository Achievements { get; }

    public UnitOfWork(AppDbContext context, ILoggerFactory loggerFactory)
    {
        _context = context;
        var logger = loggerFactory.CreateLogger("logs");

        Drivers = new DriverRepository(_context, logger);
        Achievements = new AchievementRepository(_context, logger);
    }

    public async Task<bool> CompleteAsync()
    {
        var result = await _context.SaveChangesAsync();
        return result > 0;
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}

namespace Ticketing.DataService.Repositories.Interfaces;

public class IUnitOfWork
{
    IDriverRepository Drivers { get; }
    IAchievementsRepository Achievements { get; }

    Task CompleteAsync;
}

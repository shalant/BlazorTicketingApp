using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Ticketing.DataService.Data;
using Ticketing.DataService.Repositories.Interfaces;

namespace Ticketing.DataService.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    public readonly ILogger _logger;
    protected AppDbContext _dbContext;
    internal DbSet<T> _dbset;

    public GenericRepository(
        AppDbContext context,
        ILogger _logger)
    {
        _dbContext = context;
        _logger = _logger;
        _dbset = context.Set<T>();
    }

    public virtual async Task<bool> Add(T entity)
    {
        await _dbset.AddAsync(entity);
        return true;
    }

    public virtual async Task<bool> Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public virtual Task<IEnumerable<T>> GetAll()
    {
        throw new NotImplementedException();
    }

    public virtual async Task<T?> GetById(Guid id)
    {
        return await _dbset.FindAsync(id);
    }

    public virtual async Task<bool> Update(T entity)
    {
        throw new NotImplementedException();
    }
}

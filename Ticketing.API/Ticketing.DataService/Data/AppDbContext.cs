using Microsoft.EntityFrameworkCore;
using Ticketing.Entities.DbSet;

namespace Ticketing.DataService.Data;

public class AppDbContext : DbContext
{
    public virtual DbSet<Driver> Drivers {get;set;}
    public virtual DbSet<Achievement> Achievements {get;set;}
    public virtual DbSet<Ticket> Tickets {get;set;}
    public virtual DbSet<User> Users {get;set;}
    public virtual DbSet<Project> Projects {get;set;}

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Achievement>(entity =>
        {
            entity.HasOne()
        }
            );
    }

}

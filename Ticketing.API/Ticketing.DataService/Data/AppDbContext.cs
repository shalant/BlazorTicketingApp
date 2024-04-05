using Microsoft.EntityFrameworkCore;
using Ticketing.Entities.DbSet;

namespace Ticketing.DataService.Data;

public class AppDbContext : DbContext
{
    //define DB entities
    public virtual DbSet<Driver> Drivers {get;set;}
    public virtual DbSet<Achievement> Achievements {get;set;}
    public virtual DbSet<Ticket> Tickets {get;set;}
    public virtual DbSet<User> Users {get;set;}
    public virtual DbSet<Project> Projects {get;set;}

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        //specify relationships between entities
        //TODO: figure out tickets
        modelBuilder.Entity<Achievement>(entity =>
        {
            entity.HasOne(e => e.Driver)
                .WithMany(p => p.Achievements)
                .HasForeignKey(d => d.DriverId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_Achievements_DriverId")
                .HasForeignKey(d => d.DriverId);
        }
            );
        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasOne(e => e.User)
            .WithMany(p => p.Tickets)
            .HasForeignKey(u => u.UserId)
            .OnDelete(DeleteBehavior.NoAction)
            .HasConstraintName("FK_Tickets_UserId")
            .HasForeignKey(u => u.UserId);
        }
        );
    }

}

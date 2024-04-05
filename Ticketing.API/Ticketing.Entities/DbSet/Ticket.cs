namespace Ticketing.Entities.DbSet;

public class Ticket : BaseEntity
{
    public DateTime DateDue { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Notes { get; set; }
    public Guid UserId { get; set; }

    public virtual User User { get; set; }

}

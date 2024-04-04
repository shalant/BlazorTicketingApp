namespace Ticketing.Entities.DbSet;

public class User : BaseEntity
{
    public User()
    {
        Tickets = new HashSet<Ticket>();
    }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;

    public virtual ICollection<Ticket> Tickets { get; set; }

}

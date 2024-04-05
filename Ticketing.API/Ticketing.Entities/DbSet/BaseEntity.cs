namespace Ticketing.Entities.DbSet;

public class BaseEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime AddedDate { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedDate { get; set; } = DateTime.UtcNow;
    public DateTime DeletedDate { get; set; } = DateTime.UtcNow;
    public bool Status { get; set; }
}

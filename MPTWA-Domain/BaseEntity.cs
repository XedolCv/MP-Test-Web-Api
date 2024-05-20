namespace MPTWA_Domain;

public abstract class BaseEntity
{
    public Guid Id { get; set; }
    public DateTime CreateTime { get; set; }
}
namespace MPTWA_Domain.Entities;

public class ResultsLog :BaseEntity
{
    public int VowelsCount { get; set; }
    public string SearchText { get; set; }
    public RequestLogEntity RequestLogEntity { get; set; }
    public Guid RequestLogEntityId { get; set; }
}
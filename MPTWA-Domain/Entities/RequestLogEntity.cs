using MPTWA_Infrastructure.Models.Requests;

namespace MPTWA_Domain.Entities;

public class RequestLogEntity :BaseEntity
{
    public string Section { get; set; }
    public string KeyWord { get; set; }
    public List<ResultsLog> Results { get; set; }
}
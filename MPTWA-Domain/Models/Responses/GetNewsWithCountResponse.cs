using MPTWA_Infrastructure.Models.Enums;

namespace MPTWA_Infrastructure.Services;

public class GetNewsWithCountResponse
{
    public string KeyWoard { get; set; }
    public SectionForCount Section { get; set; } = SectionForCount.title;

    public List<CounterResult> Results { get; set; } = new();
}
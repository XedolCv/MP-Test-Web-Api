using MPTWA_Infrastructure.Models.Enums;

namespace MPTWA_Infrastructure.Models.Requests;

public class GetNewsWithCountRequest
{
    public SectionForCount Section { get; set; } = SectionForCount.title;
    public string KeyWord { get; set; }
    public NewsLanguages Language { get; set; }
}
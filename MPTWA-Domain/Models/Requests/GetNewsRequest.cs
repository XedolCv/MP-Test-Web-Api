using System.Text.Json.Serialization;
using System.Web;
using MPTWA_Infrastructure.Models.Enums;
using Newtonsoft.Json.Converters;

namespace MPTWA_Infrastructure.Models.Requests;

public class GetNewsRequest
{
    public string q { get; set; }
    public SearchTypes? searchIn { get; set; }
    public int pageSize { get; set; } = 30;
    public int page { get; set; } = 1;
    public NewsLanguages language { get; set; } = NewsLanguages.en;
}

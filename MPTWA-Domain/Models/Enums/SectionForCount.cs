using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MPTWA_Infrastructure.Models.Enums;

[JsonConverter(typeof(StringEnumConverter))]
public enum SectionForCount
{
    title = 1,
    description = 2,
    content =3 
}
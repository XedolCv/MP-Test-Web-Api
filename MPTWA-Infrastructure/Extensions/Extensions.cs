using System.Text.RegularExpressions;
using System.Web;
using MPTWA_Infrastructure.Models.Enums;

namespace MPTWA_Infrastructure.Extensions;

public class Extensions
{
    public static string GetQueryString<T>(T obj)
    {
        var properties = from p in obj.GetType().GetProperties()
            where p.GetValue(obj, null) != null
            select p.Name + "=" + HttpUtility.UrlEncode(p.GetValue(obj, null).ToString());
        return String.Join("&", properties.ToArray());
    }
    public static int GetVowelCount(string input,NewsLanguages lang)
    {
        if (lang == NewsLanguages.en)
            return Regex.Matches(input, @"[aeiou]", RegexOptions.IgnoreCase).Count;
        else return Regex.Matches(input, @"[ауоыиэяюёе]", RegexOptions.IgnoreCase).Count;
    }
}
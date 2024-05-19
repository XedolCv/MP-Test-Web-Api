using System.Net;
using MPTWA_Application.Interfaces;
using Newtonsoft.Json;

namespace MPTWA_Infrastructure.Services;

public abstract class BaseApiService
{
    public static async Task<TOut?> Get<TOut, TIn>(HttpClient httpClient, string url, TIn request)
    {
        var uri = new UriBuilder(url)
        {
            Query = Extensions.Extensions.GetQueryString(request)
        };
        try
        {
            var response = await httpClient.GetAsync(uri.Uri);

            switch (response.StatusCode)
            {
                case HttpStatusCode.Unauthorized:
                    break;
                case HttpStatusCode.OK:
                case HttpStatusCode.NoContent:
                    break;
                default:
                    throw new Exception(response.ReasonPhrase);
            }
            response.EnsureSuccessStatusCode();
            var str = await response.Content.ReadAsStringAsync();
            return typeof(string) == typeof(TOut) 
                ? (TOut)(object)str
                : JsonConvert.DeserializeObject<TOut>(str);
        }
        catch (Exception e)
        {
            return default;
        }
    }
}
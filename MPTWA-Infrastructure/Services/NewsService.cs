using System.Net;
using Microsoft.Extensions.Configuration;
using MPTWA_Application.Interfaces;
using MPTWA_Infrastructure.Models.Requests;
using MPTWA_Infrastructure.Models.Responses;
using Newtonsoft.Json;

namespace MPTWA_Infrastructure.Services;

public class NewsService : INewsService
{
    private  readonly string _serviceUrl = "https://newsapi.org/v2/everything";
    private readonly HttpClient _httpClient;

    public NewsService(IConfiguration configuration)
    {
        _httpClient = new HttpClient();
        _httpClient.DefaultRequestHeaders.Add("X-Api-Key", configuration.GetSection("NewsApiKey").Value );
        _httpClient.DefaultRequestHeaders.Add("User-Agent", "PostmanRuntime/7.39.0" );
    }
    public async Task<GetNewsResponse?> GetNewsAsync(GetNewsRequest request)
    {
        return await BaseApiService.Get<GetNewsResponse, GetNewsRequest>(_httpClient, _serviceUrl, request);
    }
}
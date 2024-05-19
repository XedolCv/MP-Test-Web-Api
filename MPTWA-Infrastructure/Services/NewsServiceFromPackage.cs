using AutoMapper;
using Microsoft.Extensions.Configuration;
using MPTWA_Application.Interfaces;
using MPTWA_Infrastructure.Models.Requests;
using NewsAPI;
using NewsAPI.Models;

namespace MPTWA_Infrastructure.Services;

public class NewsServiceFromPackage  :INewsServiceFromPackage
{
    private readonly IMapper _mapper;
    private IConfiguration _configuration;
    private readonly NewsApiClient _newsApiClient;

    public NewsServiceFromPackage(IMapper mapper, IConfiguration configuration)
    {
        _mapper = mapper;
        _configuration = configuration;
        _newsApiClient = new NewsApiClient(configuration.GetSection("NewsApiKey").Value);
    }

    public async Task<NewsAPI.Models.ArticlesResult> GetNews(GetNewsRequest request)
    {
        try
        {
            return await _newsApiClient.GetEverythingAsync(_mapper.Map<EverythingRequest>(request));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}
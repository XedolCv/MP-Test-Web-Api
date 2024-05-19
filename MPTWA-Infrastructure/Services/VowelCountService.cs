using System.Text.RegularExpressions;
using AutoMapper;
using MPTWA_Application.Interfaces;
using MPTWA_Infrastructure.Models.Enums;
using MPTWA_Infrastructure.Models.Requests;
using MPTWA_Infrastructure.Models.Responses;

namespace MPTWA_Infrastructure.Services;

public class VowelCountService : IVowelCountService
{
    private static IMapper _mapper;
    private static INewsService _newsService;
    private static ILogToDbService _logToDbService;
    private static INewsServiceFromPackage _newsServiceFromPackage;

    public VowelCountService(IMapper mapper, INewsService newsService, INewsServiceFromPackage newsServiceFromPackage,
        ILogToDbService logToDbService)
    {
        _mapper = mapper;
        _newsService = newsService;
        _newsServiceFromPackage = newsServiceFromPackage;
        _logToDbService = logToDbService;
    }

    public async Task<GetNewsWithCountResponse> GetNewsWithCounter(GetNewsWithCountRequest request)
    {
        try
        {
            GetNewsWithCountResponse response = new GetNewsWithCountResponse();
            response.Section = request.Section;
            var lang = request.Language;
            var news = await _newsService.GetNewsAsync(_mapper.Map<GetNewsRequest>(request));
            if (news != null && news.articles.Count > 0)
            {
                switch (request.Section)
                {
                    case SectionForCount.title:
                        foreach (var n in news.articles)
                        {
                            response.Results.Add(new CounterResult
                            {
                                SectionText = n.title, VowelCount = Extensions.Extensions.GetVowelCount(n.title, lang)
                            });
                        }

                        break;
                    case SectionForCount.content:
                        foreach (var n in news.articles)
                        {
                            response.Results.Add(new CounterResult
                            {
                                SectionText = n.content,
                                VowelCount = Extensions.Extensions.GetVowelCount(n.content, lang)
                            });
                        }

                        break;
                    case SectionForCount.description:
                        foreach (var n in news.articles)
                        {
                            response.Results.Add(new CounterResult
                            {
                                SectionText = n.description,
                                VowelCount = Extensions.Extensions.GetVowelCount(n.description, lang)
                            });
                        }

                        break;
                }

                response.KeyWoard = request.KeyWord;
                response.Section = request.Section;
                response.Results = response.Results.OrderByDescending(n => n.VowelCount).ToList();
                await _logToDbService.LogToDb(_mapper.Map<RequestLogBaseModel>(response));
            }
            return response;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw e;
        }
    }

    public async Task<GetNewsWithCountResponse> GetNewsWithCounterFromPackage(GetNewsWithCountRequest request)
    {
        try
        {
            GetNewsWithCountResponse response = new GetNewsWithCountResponse();
            response.Section = request.Section;
            var lang = request.Language;
            var news = await _newsServiceFromPackage.GetNews(_mapper.Map<GetNewsRequest>(request));
            if (news != null && news.Articles.Count > 0)
            {
                switch (request.Section)
                {
                    case SectionForCount.title:
                        foreach (var n in news.Articles)
                        {
                            response.Results.Add(new CounterResult
                            {
                                SectionText = n.Title, VowelCount = Extensions.Extensions.GetVowelCount(n.Title, lang)
                            });
                        }

                        break;
                    case SectionForCount.content:
                        foreach (var n in news.Articles)
                        {
                            response.Results.Add(new CounterResult
                            {
                                SectionText = n.Content,
                                VowelCount = Extensions.Extensions.GetVowelCount(n.Content, lang)
                            });
                        }

                        break;
                    case SectionForCount.description:
                        foreach (var n in news.Articles)
                        {
                            response.Results.Add(new CounterResult
                            {
                                SectionText = n.Description,
                                VowelCount = Extensions.Extensions.GetVowelCount(n.Description, lang)
                            });
                        }

                        break;
                }

                response.Results = response.Results.OrderByDescending(n => n.VowelCount).ToList();
                await _logToDbService.LogToDb(_mapper.Map<RequestLogBaseModel>(response));
            }
            return response;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw e;
        }
    }

    public Task<RequestLogBaseModel?> GetLastResult()
    {
        try
        {
            return _logToDbService.GetLastResult();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}
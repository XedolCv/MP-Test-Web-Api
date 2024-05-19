using MPTWA_Infrastructure.Models.Requests;

namespace MPTWA_Application.Interfaces;

public interface INewsServiceFromPackage
{
    Task<NewsAPI.Models.ArticlesResult> GetNews(GetNewsRequest request);
}
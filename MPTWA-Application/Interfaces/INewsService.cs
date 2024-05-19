using MPTWA_Infrastructure.Models.Requests;
using MPTWA_Infrastructure.Models.Responses;

namespace MPTWA_Application.Interfaces;

public interface INewsService
{
    Task<GetNewsResponse?> GetNewsAsync(GetNewsRequest request);
}
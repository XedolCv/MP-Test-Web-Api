using MPTWA_Infrastructure.Models.Requests;
using MPTWA_Infrastructure.Services;

namespace MPTWA_Application.Interfaces;

public interface IVowelCountService
{
    Task<GetNewsWithCountResponse> GetNewsWithCounter(GetNewsWithCountRequest request);
    Task<GetNewsWithCountResponse> GetNewsWithCounterFromPackage(GetNewsWithCountRequest request);
    Task<RequestLogBaseModel?> GetLastResult();
}
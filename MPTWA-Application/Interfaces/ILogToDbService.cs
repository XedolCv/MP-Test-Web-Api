using MPTWA_Infrastructure.Services;

namespace MPTWA_Application.Interfaces;

public interface ILogToDbService
{
    public Task<RequestLogBaseModel> LogToDb(RequestLogBaseModel request);
    public Task<RequestLogBaseModel?> GetLastResult();
}


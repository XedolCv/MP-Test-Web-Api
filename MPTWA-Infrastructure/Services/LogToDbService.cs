using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MPTWA_Application.Interfaces;
using MPTWA_Domain.Entities;

namespace MPTWA_Infrastructure.Services;

public class LogToDbService : ILogToDbService
{
    private readonly IRepository<LogContext> _repository;
    private readonly IMapper _mapper;

    public LogToDbService(IRepository<LogContext> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<RequestLogBaseModel> LogToDb(RequestLogBaseModel request)
    {
        try
        {
            var log = _mapper.Map<RequestLogEntity>(request);
            await _repository.AddAsync(log);
            await _repository.SaveChangesAsync();
            return _mapper.Map<RequestLogBaseModel>(log);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<RequestLogBaseModel?> GetLastResult()
    {
        try
        {
            var res = await _repository.GetLastAsync<RequestLogEntity>();
            if (res != null)
                res.Results =
                    _mapper.Map<List<ResultsLog>>(_repository.Get<ResultsLog>(e => e.RequestLogEntityId == res.Id));
            return _mapper.Map<RequestLogBaseModel>(res);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}
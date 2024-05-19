using AutoMapper;
using AutoMapper.EquivalencyExpression;
using MPTWA_Domain.Entities;
using MPTWA_Infrastructure.Models.Enums;
using MPTWA_Infrastructure.Models.Requests;
using MPTWA_Infrastructure.Services;
using NewsAPI.Constants;

namespace MPTWA_Infrastructure.Configurations;

public class MapperConfigurations : Profile
{
    public MapperConfigurations()
    {
        CreateMap<RequestLogBaseModel, RequestLogEntity>().ReverseMap();
        CreateMap<RequestLogBaseModel, ResultsLog>().ReverseMap().EqualityComparison((a, b) => a.Id == b.Id);;
        CreateMap<ResultLogBaseModel, CounterResult>()
            .ForMember(dist=>dist.SectionText,src=>src.MapFrom(s=>s.SearchText))
            .ForMember(dist=>dist.VowelCount,src=>src.MapFrom(s=>s.VowelsCount))
            .ReverseMap();
        CreateMap<ResultsLog, ResultLogBaseModel>().ReverseMap();
        CreateMap<GetNewsWithCountResponse, RequestLogBaseModel>()
            .ForMember(dist=>dist.KeyWord,src=>src.MapFrom(s=>s.KeyWoard))
            .ForMember(dist=>dist.Section,src=>src.MapFrom(s=>s.Section.ToString()))
            .ForMember(dist=>dist.Results,src=>src.MapFrom(s=>s.Results))
            .ReverseMap();
        CreateMap<GetNewsRequest, NewsAPI.Models.EverythingRequest>()
            .ForMember(dest => dest.Q, src => src.MapFrom(s => s.q))
            .ForMember(dest => dest.Page, src => src.MapFrom(s => s.page))
            .ForMember(dest => dest.PageSize, src => src.MapFrom(s => s.pageSize))
            .ForMember(dest => dest.Sources, src => src.MapFrom(s => s.searchIn.ToString().ToList()))
            .ForMember(dest => dest.Language, src => src.MapFrom(s => s.language == NewsLanguages.en ? Languages.EN : Languages.RU));
        CreateMap<GetNewsWithCountRequest, GetNewsRequest>()
            .ForMember(dest => dest.q, src => src.MapFrom(s => s.KeyWord));
    }
}
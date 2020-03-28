using AutoMapper;
using BusinessesDirectoryApi.Dtos.CreateDtos.BusinessDtos;
using BusinessesDirectoryApi.Dtos.ReturnDtos.BusinessReturnDtos;
using BusinessesDirectoryApi.Dtos.ReturnDtos.LocationReturnDtos;
using BusinessesDirectoryApi.Dtos.ReturnDtos.TypesReturnDtos;
using BusinessesDirectoryApi.Models.AdministrationModels;
using BusinessesDirectoryApi.Models.BusinessModels;
using BusinessesDirectoryApi.Models.LocationModels;

namespace BusinessesDirectoryApi.Helpers
{
  public class AutomapperProfiles : Profile
  {
    public AutomapperProfiles()
    {
      CreateMap<Country, CountryDto>()
        .ForMember(dest => dest.Name, opts => opts.MapFrom(src => src.CountryName))
        .ForMember(dest => dest.NormalizedName, opts => opts.MapFrom(src => src.CountryNormalizedName))
        .ForMember(dest => dest.Iso2, opts => opts.MapFrom(src => src.IsoTwo));
      CreateMap<City, CityDto>()
        .ForMember(dest => dest.Name, opts => opts.MapFrom(src => src.CityName))
        .ForMember(dest => dest.NormalizedName, opts => opts.MapFrom(src => src.CityNormalizedName));
      CreateMap<State, StateDto>()
        .ForMember(dest => dest.Name, opts => opts.MapFrom(src => src.StateName))
        .ForMember(dest => dest.Name, opts => opts.MapFrom(src => src.StateNormalizedName));
      CreateMap<BusinessType, BusinessTypeDto>()
        .ForMember(dest => dest.Name, opts => opts.MapFrom(src => src.BusinessTypeName))
        .ForMember(dest => dest.NormalizedName, opts => opts.MapFrom(src => src.BusinessTypeNormalizedName));
      CreateMap<BusinessHours, BusinessHoursDto>();
      CreateMap<Business, BusinessDto>()
        .ForMember(dest => dest.BusinessDaysAndHours, opts => opts.MapFrom(src => src.BusinessDaysAndHours))
        .ForMember(dest => dest.BusinessType, opts => opts.MapFrom(src => src.BusinessType))
        .ForMember(dest => dest.City, opts => opts.MapFrom(src => src.City));
      CreateMap<BusinessHoursToCreateDto,BusinessHours>();
      CreateMap<BusinessToCreateDto,Business>();
    }
  }
}

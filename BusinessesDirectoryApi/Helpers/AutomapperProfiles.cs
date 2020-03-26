using AutoMapper;
using BusinessesDirectoryApi.Dtos.ReturnDtos.LocationReturnDtos;
using BusinessesDirectoryApi.Dtos.ReturnDtos.TypesReturnDtos;
using BusinessesDirectoryApi.Models.AdministrationModels;
using BusinessesDirectoryApi.Models.LocationModels;

namespace BusinessesDirectoryApi.Helpers
{
  public class AutomapperProfiles : Profile
  {
    public AutomapperProfiles()
    {
      CreateMap<Country, CountryDto>();
      CreateMap<City, CityDto>();
      CreateMap<State, StateDto>();
      CreateMap<BusinessType, BusinessTypeDto>();
    }
  }
}
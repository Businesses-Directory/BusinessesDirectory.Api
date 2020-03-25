using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using BusinessesDirectoryApi.Dtos.ReturnDtos.LocationReturnDtos;

namespace BusinessesDirectoryApi.Services
{
  public interface ILocationService
  {
    Task<ICollection<CityDto>> FindAllCities();
    Task<CityDto> FindCity(Guid id);
  }
}
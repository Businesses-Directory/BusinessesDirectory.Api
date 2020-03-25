using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BusinessesDirectoryApi.Dtos.ReturnDtos.LocationReturnDtos;
using BusinessesDirectoryApi.Repositories;

namespace BusinessesDirectoryApi.Services
{
  public class LocationService : ILocationService
  {
    private readonly ILocationRepository _locationRepository;
    private readonly IMapper _mapper;
    public LocationService(ILocationRepository locationRepository, IMapper mapper)
    {
      this._locationRepository = locationRepository;
      this._mapper = mapper;
    }
    public async Task<ICollection<CityDto>> FindAllCities()
    {
      var cities = await _locationRepository.FindAllCities();
      return _mapper.Map<ICollection<CityDto>>(cities);
    }
    public async Task<CityDto> FindCity(Guid id)
    {
      var city = await _locationRepository.FindCity(id);
      if (city == null)
      {
        throw new Exception("The city was not found");
      }
      return _mapper.Map<CityDto>(city);
    }
  }
}
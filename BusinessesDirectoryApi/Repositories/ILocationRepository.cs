using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using BusinessesDirectoryApi.Models.LocationModels;

namespace BusinessesDirectoryApi.Repositories
{
  public interface ILocationRepository
  {
    Task<ICollection<City>> FindAllCities();
    Task<City> FindCityById(Guid id);
    Task<State> FindStateById(Guid id);
    Task<Country> FindCountryById(Guid id);
  }
}

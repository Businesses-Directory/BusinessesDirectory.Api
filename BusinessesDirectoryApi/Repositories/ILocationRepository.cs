using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using BusinessesDirectoryApi.Models.LocationModels;

namespace BusinessesDirectoryApi.Repositories
{
  public interface ILocationRepository
  {
    Task<ICollection<City>> FindAllCities();
    Task<City> FindCity(Guid id);
  }
}
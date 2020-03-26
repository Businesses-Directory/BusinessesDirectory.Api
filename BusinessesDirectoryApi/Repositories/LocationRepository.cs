using System;
using AutoMapper;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using BusinessesDirectoryApi.Models.ContextModel;
using BusinessesDirectoryApi.Models.LocationModels;
using BusinessesDirectoryApi.Dtos.ReturnDtos.LocationReturnDtos;

namespace BusinessesDirectoryApi.Repositories
{
  public class LocationRepository : ILocationRepository
  {
    private readonly BusinessesDirectoryContext _context;
    public LocationRepository(BusinessesDirectoryContext context)
    {
      this._context = context;
    }
    public async Task<ICollection<City>> FindAllCities()
    {
      return await _context.City.ToListAsync();
    }
    public async Task<City> FindCity(Guid id)
    {
      var city = await _context.City.FirstOrDefaultAsync(c => c.CityId == id);
      return city;
    }
  }
}
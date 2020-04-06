using System;
using AutoMapper;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using BusinessesDirectoryApi.Models.ContextModel;
using BusinessesDirectoryApi.Models.LocationModels;
using BusinessesDirectoryApi.Dtos.ReturnDtos.LocationReturnDtos;
using System.Linq;

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
            return await _context.City
              .OrderBy(c => c.CityNormalizedName)
              .ToListAsync();
        }
        public async Task<City> FindCityById(Guid id)
        {
            var city = await _context.City.FirstOrDefaultAsync(c => c.CityId == id);
            return city;
        }
        public async Task<State> FindStateById(Guid id)
        {
            var state = await _context.State.FirstOrDefaultAsync(s => s.StateId == id);
            return state;
        }
        public async Task<Country> FindCountryById(Guid id)
        {
            var country = await _context.Country.FirstOrDefaultAsync(c => c.CountryId == id);
            return country;
        }
    }
}

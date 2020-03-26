using System.Collections.Generic;
using System.Linq;
using BusinessesDirectoryApi.Helpers;
using BusinessesDirectoryApi.Models.AdministrationModels;
using BusinessesDirectoryApi.Models.BusinessModels;
using BusinessesDirectoryApi.Models.ContextModel;
using BusinessesDirectoryApi.Models.LocationModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

namespace BusinessesDirectoryApi.Models.SeedModel
{
  public class Seed
  {
    private readonly BusinessesDirectoryContext _context;
    private readonly IHostingEnvironment _environment;
    public Seed(BusinessesDirectoryContext context, IHostingEnvironment environment)
    {
      this._context = context;
      this._environment = environment;
    }
    public void SeedDb()
    {
      _context.Database.Migrate();
      SeedLocations();
      SeedTypes();
      if (_environment.IsDevelopment())
      {
        SeedBusinesses();
      }
      _context.SaveChanges();
    }
    private void AddRangeToContext<T>(List<T> data) where T : class
    {
      var set = _context.Set<T>();
      if (!set.Any())
        set.AddRange(data);
    }
    private void SeedLocations()
    {
      AddRangeToContext(JsonSerializer.GetDataFromFile<List<Country>>("Models/LocationModels/LocationModelsSeeds/CountrySeed.json"));
      AddRangeToContext(JsonSerializer.GetDataFromFile<List<State>>("Models/LocationModels/LocationModelsSeeds/StateSeed.json"));
      AddRangeToContext(JsonSerializer.GetDataFromFile<List<City>>("Models/LocationModels/LocationModelsSeeds/CitySeed.json"));
    }
    private void SeedTypes()
    {
      AddRangeToContext(JsonSerializer.GetDataFromFile<List<BusinessType>>("Models/AdministrationModels/AdministrationModelsSeeds/BusinessTypeSeed.json"));
    }
    private void SeedBusinesses()
    {
      AddRangeToContext(JsonSerializer.GetDataFromFile<List<Business>>("Models/BusinessModels/BusinessModelsSeed/BusinessSeed.json"));
    }
  }
}

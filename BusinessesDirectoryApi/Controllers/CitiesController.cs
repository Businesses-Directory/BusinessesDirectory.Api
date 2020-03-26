using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessesDirectoryApi.Services;
using BusinessesDirectoryApi.Validations;
using Microsoft.AspNetCore.Mvc;

namespace BusinessesDirectoryApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CitiesController : ControllerBase
  {
    private readonly ILocationService _locationService;
    public CitiesController(ILocationService locationService)
    {
      this._locationService = locationService;
    }
    [HttpGet]
    public async Task<IActionResult> GetCities()
    {
      var cities = await _locationService.FindAllCities();
      return Ok(cities);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCity([GuidValidationAttribute] string id)
    {
      var city = await _locationService.FindCity(Guid.Parse(id));
      return Ok(city);
    }

    // POST api/values
    // [HttpPost]
    // public void Post([FromBody] string value)
    // {
    // }

    // // PUT api/values/5
    // [HttpPut("{id}")]
    // public void Put(int id, [FromBody] string value)
    // {
    // }

    // // DELETE api/values/5
    // [HttpDelete("{id}")]
    // public void Delete(int id)
    // {
    // }
  }
}

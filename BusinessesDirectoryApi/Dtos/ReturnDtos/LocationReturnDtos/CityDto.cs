using System;

namespace BusinessesDirectoryApi.Dtos.ReturnDtos.LocationReturnDtos
{
  public class CityDto
  {
    public Guid CityId { get; set; }
    public Guid StateId { get; set; }
    public Guid CountryId { get; set; }
    public string CityName { get; set; }
  }
}
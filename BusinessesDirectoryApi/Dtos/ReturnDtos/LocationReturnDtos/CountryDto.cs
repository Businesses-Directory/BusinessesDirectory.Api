using System;

namespace BusinessesDirectoryApi.Dtos.ReturnDtos.LocationReturnDtos
{
  public class CountryDto
  {
    public Guid CountryId { get; set; }
    public string Name { get; set; }
    public string NormalizedName { get; set; }
    public string Iso2 {get; set; }
  }
}

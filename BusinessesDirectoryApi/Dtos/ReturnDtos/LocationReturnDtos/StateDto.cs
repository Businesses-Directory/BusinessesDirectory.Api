using System;

namespace BusinessesDirectoryApi.Dtos.ReturnDtos.LocationReturnDtos
{
  public class StateDto
  {
    public Guid StateId { get; set; }
    public Guid CountryId { get; set; }
    public string Name { get; set; }
    public string NomalizedName { get; set; }
  }
}

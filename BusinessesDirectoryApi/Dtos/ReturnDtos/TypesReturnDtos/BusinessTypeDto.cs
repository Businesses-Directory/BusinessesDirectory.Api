using System;

namespace BusinessesDirectoryApi.Dtos.ReturnDtos.TypesReturnDtos
{
  public class BusinessTypeDto
  {
    public Guid BusinessTypeId { get; set; }
    public string Name { get; set; }
    public string NormalizedName { get; set; }
  }
}

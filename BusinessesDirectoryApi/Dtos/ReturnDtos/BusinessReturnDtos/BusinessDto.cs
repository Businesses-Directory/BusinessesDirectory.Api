using System;
using BusinessesDirectoryApi.Dtos.ReturnDtos.LocationReturnDtos;
using BusinessesDirectoryApi.Dtos.ReturnDtos.TypesReturnDtos;

namespace BusinessesDirectoryApi.Dtos.ReturnDtos.BusinessReturnDtos
{
  public class BusinessDto
  {
    public Guid BusinessId { get; set; }
    public string BusinessName { get; set; }
    public string BusinessEmail { get; set; }
    public BusinessTypeDto BusinessType { get; set; }
    public string BusinessDescription { get; set; }
    public string PrimaryPhoneNumber { get; set; }
    public string SecondaryPhoneNumber { get; set; }
    public BusinessHoursDto BusinessDaysAndHours { get; set; }
    public CityDto City { get; set; }
    public string InFacebookAs { get; set; }
    public string InInstagramAs { get; set; }
    public bool HasDelivery { get; set; }
    public bool HasCarryOut { get; set; }
    public bool HasAthMovil { get; set; }
    public bool InUberEats { get; set; }
    public bool InDameUnBite { get; set; }
    public bool InUva { get; set; }
  }
}

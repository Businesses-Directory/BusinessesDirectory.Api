using System.Collections.Generic;
using BusinessesDirectoryApi.Validations;
using System.ComponentModel.DataAnnotations;

namespace BusinessesDirectoryApi.Dtos.CreateDtos.BusinessDtos
{
  public class BusinessToCreateDto
  {
    [Required (ErrorMessage = "Please specify the business name.")]
    public string BusinessName { get; set; }
    [GuidValidationAttribute (ErrorMessage = "Please use a valid GUID/UUIDV4 for the BusinessTypeId.")]
    public string BusinessTypeId { get; set; }
    [Required (ErrorMessage = "The Business description must be sent")]
    public string BusinessDescription { get; set; }
    [Required (ErrorMessage = "Please enter the primary phone number.")]
    [Phone (ErrorMessage = "Please enter a valid phone number.")]
    public string PrimaryPhoneNumber { get; set; }
    public string SecondaryPhoneNumber { get; set; }
    [GuidValidationAttribute (ErrorMessage = "Please use a valid GUID/UUIDV4 for the cityd.")]
    [Required (ErrorMessage = "The city UUID is required.")]
    public string CityId { get; set; }
    [GuidValidationAttribute (ErrorMessage = "Please use a valid GUID/UUIDV4 for the stateId.")]
    [Required (ErrorMessage = "The country UUID is required.")]
    public string StateId { get; set; }
    [GuidValidationAttribute (ErrorMessage = "Please use a valid GUID/UUIDV4 for the countryId.")]
    [Required (ErrorMessage = "The country UUID is required.")]
    public string CountryId { get; set; }
    public string InFacebookAs { get; set; }
    public string InInstagramAs { get; set; }
    [Required (ErrorMessage = "Please indicate if your business has delivery service.")]
    public bool HasDelivery { get; set; }
    [Required (ErrorMessage = "Please indicate if your business has carry-out service.")]
    public bool HasCarryOut { get; set; }
    [Required (ErrorMessage = "Please indicate if the customers can pay with ATHMovil service.")]
    public bool HasAthMovil { get; set; }
    [Required]
    public bool InUberEats { get; set; }
    [Required]
    public bool InDameUnBite { get; set; }
    [Required]
    public bool InUva { get; set; }
    [Required (ErrorMessage = "Please send the business hours.")]
    public BusinessHoursToCreateDto BusinessDaysAndHours { get; set; }
  }
}

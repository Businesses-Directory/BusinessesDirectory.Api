using System.Collections.Generic;
using BusinessesDirectoryApi.Validations;
using System.ComponentModel.DataAnnotations;

namespace BusinessesDirectoryApi.Dtos.CreateDtos.BusinessDtos
{
  public class BusinessToCreateDto
  {
    [Required (ErrorMessage = "Especifique el nombre del negocio.")]
    public string BusinessName { get; set; }
    [GuidValidationAttribute (ErrorMessage = "Please use a valid GUID/UUIDV4 for the BusinessTypeId.")]
    [Required]
    public string BusinessTypeId { get; set; }
    [Required (ErrorMessage = "Especifique la descripción del negocio.")]
    public string BusinessDescription { get; set; }
    [Required (ErrorMessage = "Escriba el número telefónico primario del negocio.")]
    [Phone (ErrorMessage = "Escriba un número telefónico válido.")]
    public string PrimaryPhoneNumber { get; set; }
    [Phone (ErrorMessage = "Escriba un número telefónico válido.")]
    public string SecondaryPhoneNumber { get; set; }
    [GuidValidationAttribute (ErrorMessage = "El id de la ciudad no es válido, utilice un UUIDV4.")]
    [Required (ErrorMessage = "El id de la ciudad es requerido.")]
    public string CityId { get; set; }
    [GuidValidationAttribute (ErrorMessage = "El id del estado no es válido, utilice un UUIDV4.")]
    [Required (ErrorMessage = "El id del estado es requerido.")]
    public string StateId { get; set; }
    [GuidValidationAttribute (ErrorMessage = "El id del país no es válido, utilice un UUIDV4.")]
    [Required (ErrorMessage = "El Id del país es requerido.")]
    public string CountryId { get; set; }
    public string InFacebookAs { get; set; }
    public string InInstagramAs { get; set; }
    [Required (ErrorMessage = "Indique si el negocio tiene servicio de delivery.")]
    public bool HasDelivery { get; set; }
    [Required (ErrorMessage = "Indique si el negocio tiene servicio de recogido de órden (carry-out).")]
    public bool HasCarryOut { get; set; }
    [Required (ErrorMessage = "Indique si el negocio tiene servicio de ATH móvil.")]
    public bool HasAthMovil { get; set; }
    [Required (ErrorMessage = "Indique si el negocio se encuentra en Uber Eats.")]
    public bool InUberEats { get; set; }
    [Required (ErrorMessage = "Indique si el negocio se encuentra en Dame un Bite.")]
    public bool InDameUnBite { get; set; }
    [Required (ErrorMessage = "Indique si el negocio se encuentra en Uva.")]
    public bool InUva { get; set; }
    [Required (ErrorMessage = "Indique el itinerario del negocio.")]
    public BusinessHoursToCreateDto BusinessDaysAndHours { get; set; }
  }
}

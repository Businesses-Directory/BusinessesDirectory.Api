using System.ComponentModel.DataAnnotations;
using BusinessesDirectoryApi.Validations;

namespace BusinessesDirectoryApi.Dtos.CreateDtos.BusinessDtos
{
  public class BusinessHoursToCreateDto
  {
    [Required (ErrorMessage = "Indique si el negocio está abierto los lunes.")]
    public bool Monday { get; set; }
    [
      OperationHoursValidationAttribute
      (
        ErrorMessage = "Verifique el formato entrado en las horas de servicio para el lunes."
      )
    ]
    public string MondayHours  { get; set; }
    [Required (ErrorMessage = "Indique si el negocio está abierto los martes.")]
    public bool Tuesday { get; set; }
    [
      OperationHoursValidationAttribute
      (
        ErrorMessage = "Verifique el formato entrado en las horas de servicio para el martes."
      )
    ]
    public string TuesdayHours  { get; set; }
    [Required (ErrorMessage = "Indique si el negocio está abierto los miércoles.")]
    public bool Wednesday { get; set; }
    [
      OperationHoursValidationAttribute
      (
        ErrorMessage = "Verifique el formato entrado en las horas de servicio para el miércoles."
      )
    ]
    public string WednesdayHours { get; set; }
    [Required (ErrorMessage = "Indique si el negocio está abierto los jueves.")]
    public bool Thursday { get; set; }
    [
      OperationHoursValidationAttribute
      (
        ErrorMessage = "Verifique el formato entrado en las horas de servicio para el jueves."
      )
    ]
    public string ThursdayHours { get; set; }
    [Required (ErrorMessage = "Indique si el negocio está abierto los viernes.")]
    public bool Friday { get; set; }
    [
      OperationHoursValidationAttribute
      (
        ErrorMessage = "Verifique el formato entrado en las horas de servicio para el viernes."
      )
    ]
    public string FridayHours { get; set; }
    [Required (ErrorMessage = "Indique si el negocio está abierto los sábados.")]
    public bool Saturday { get; set; }
    [
      OperationHoursValidationAttribute
      (
        ErrorMessage = "Verifique el formato entrado en las horas de servicio para el sábado."
      )
    ]
    public string SaturdayHours { get; set; }
    [Required (ErrorMessage = "Indique si el negocio está abierto los domingos.")]
    public bool Sunday { get; set; }
    [
      OperationHoursValidationAttribute
      (
        ErrorMessage = "Verifique el formato entrado en las horas de servicio para el domingo."
      )
    ]
    public string SundayHours { get; set; }
  }
}

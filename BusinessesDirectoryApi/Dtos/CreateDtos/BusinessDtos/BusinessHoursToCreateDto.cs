using System.ComponentModel.DataAnnotations;
using BusinessesDirectoryApi.Validations;

namespace BusinessesDirectoryApi.Dtos.CreateDtos.BusinessDtos
{
  public class BusinessHoursToCreateDto
  {
    [Required (ErrorMessage = "Please indicate if the business operates on Mondays.")]
    public bool Monday { get; set; }
    [
      OperationHoursValidationAttribute
      (
        ErrorMessage = "The business hours entered for Monday are not in the correct format."
      )
    ]
    public string MondayHours  { get; set; }
    [Required (ErrorMessage = "Please indicate if the business operates on Tuesdays.")]
    public bool Tuesday { get; set; }
    [
      OperationHoursValidationAttribute
      (
        ErrorMessage = "The business hours entered for Tuesday are not in the correct format."
      )
    ]
    public string TuesdayHours  { get; set; }
    [Required (ErrorMessage = "Please indicate if the business operates on Wednesdays.")]
    public bool Wednesday { get; set; }
    [
      OperationHoursValidationAttribute
      (
        ErrorMessage = "The business hours entered for Wenesday are not in the correct format."
      )
    ]
    public string WednesdayHours { get; set; }
    [Required (ErrorMessage = "Please indicate if the business operates on Thursdays.")]
    public bool Thursday { get; set; }
    [
      OperationHoursValidationAttribute
      (
        ErrorMessage = "The business hours entered for Thusrday are not in the correct format."
      )
    ]
    public string ThursdayHours { get; set; }
    [Required (ErrorMessage = "Please indicate if the business operates on Fridays.")]
    public bool Friday { get; set; }
    [
      OperationHoursValidationAttribute
      (
        ErrorMessage = "The business hours entered for Friday are not in the correct format."
      )
    ]
    public string FridayHours { get; set; }
    [Required (ErrorMessage = "Please indicate if the business operates on Saturdays.")]
    public bool Saturday { get; set; }
    [
      OperationHoursValidationAttribute
      (
        ErrorMessage = "The business hours entered for Saturday are not in the correct format."
      )
    ]
    public string SaturdayHours { get; set; }
    [Required (ErrorMessage = "Please indicate if the business operates on Sundays.")]
    public bool Sunday { get; set; }
    [
      OperationHoursValidationAttribute
      (
        ErrorMessage = "The business hours entered for Sunday are not in the correct format."
      )
    ]
    public string SundayHours { get; set; }
  }
}

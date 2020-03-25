using System.ComponentModel.DataAnnotations;

namespace BusinessesDirectoryApi.Dtos.CreateDtos.BusinessDtos
{
  public class BusinessHoursToCreateDto
  {
    [Required (ErrorMessage = "Please indicate if the business operates on Mondays.")]
    public bool Monday { get; set; }
    public string MondayHours  { get; set; }
    [Required (ErrorMessage = "Please indicate if the business operates on Tuesdays.")]
    public bool Tuesday { get; set; }
    public string TuesdayHours  { get; set; }
    [Required (ErrorMessage = "Please indicate if the business operates on Wednesdays.")]
    public bool Wednesday { get; set; }
    public string WednesdayHours { get; set; }
    [Required (ErrorMessage = "Please indicate if the business operates on Thursdays.")]
    public bool Thursday { get; set; }
    public bool ThursdayHours { get; set; }
    [Required (ErrorMessage = "Please indicate if the business operates on Fridays.")]
    public bool Friday { get; set; }
    public bool FridayHours { get; set; }
    [Required (ErrorMessage = "Please indicate if the business operates on Saturdays.")]
    public bool Saturday { get; set; }
    public string SaturdayHours { get; set; }
    [Required (ErrorMessage = "Please indicate if the business operates on Sundays.")]
    public bool Sunday { get; set; }
    public bool SundayHours { get; set; }
  }
}
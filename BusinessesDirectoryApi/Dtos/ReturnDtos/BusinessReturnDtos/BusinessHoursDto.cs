using BusinessesDirectoryApi.Models.BusinessModels;

namespace BusinessesDirectoryApi.Dtos.ReturnDtos.BusinessReturnDtos
{
  public class BusinessHoursDto
  {
    public BusinessHoursDto(BusinessHours itinerary)
    {
      this.Monday = itinerary.Monday;
      this.MondayHours = itinerary.MondayHours;
      this.Tuesday = itinerary.Tuesday;
      this.ThursdayHours = itinerary.TuesdayHours;
      this.Wednesday = itinerary.Wednesday;
      this.WednesdayHours = itinerary.WednesdayHours;
      this.Thursday = itinerary.Thursday;
      this.ThursdayHours = itinerary.ThursdayHours;
      this.Friday = itinerary.Friday;
      this.FridayHours = itinerary.FridayHours;
      this.Saturday = itinerary.Saturday;
      this.SaturdayHours = itinerary.SaturdayHours;
      this.Sunday = itinerary.Sunday;
      this.SundayHours = itinerary.SundayHours;
    }
    public bool Monday { get; set; }
    public string MondayHours  { get; set; }
    public bool Tuesday { get; set; }
    public string TuesdayHours  { get; set; }
    public bool Wednesday { get; set; }
    public string WednesdayHours { get; set; }
    public bool Thursday { get; set; }
    public string ThursdayHours { get; set; }
    public bool Friday { get; set; }
    public string FridayHours { get; set; }
    public bool Saturday { get; set; }
    public string SaturdayHours { get; set; }
    public bool Sunday { get; set; }
    public string SundayHours { get; set; }
  }
}

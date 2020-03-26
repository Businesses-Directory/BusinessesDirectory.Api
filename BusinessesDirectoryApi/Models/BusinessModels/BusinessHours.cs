using BusinessesDirectoryApi.Helpers;

namespace BusinessesDirectoryApi.Models.BusinessModels
{
  public class BusinessHours
  {
    public bool Monday { get; set; } // Default value: false
    public string MondayHours  { get; set; } // "8:30AM - 5:30PM"
    public bool Tuesday { get; set; } // Default value: false
    public string TuesdayHours  { get; set; } // "8:30AM - 5:30PM"
    public bool Wednesday { get; set; } // Default value: false
    public string WednesdayHours { get; set; } // "8:30AM - 5:30PM"
    public bool Thursday { get; set; } // Default value: false
    public bool ThursdayHours { get; set; } // "8:30AM - 5:30PM"
    public bool Friday { get; set; } // Default value: false
    public bool FridayHours { get; set; } // "8:30AM - 5:30PM"
    public bool Saturday { get; set; } // Default value: false
    public string SaturdayHours { get; set; } // "8:30AM - 5:30PM"
    public bool Sunday { get; set; } // Default value: false
    public bool SundayHours { get; set; } // "8:30AM - 5:30PM"

    public override string ToString()
    {
      return JsonSerializer.Serialize(this);
    }
    public static BusinessHours ValueToBusinessHours(string jsonSerializedValue)
    {
      return JsonSerializer.Parse<BusinessHours>(jsonSerializedValue);
    }
  }
}
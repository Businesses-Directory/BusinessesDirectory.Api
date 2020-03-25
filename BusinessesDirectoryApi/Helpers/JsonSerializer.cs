using Newtonsoft.Json;

namespace BusinessesDirectoryApi.Helpers
{
  public class JsonSerializer
  {
    public static T Parse<T>(string json)
    {
      return JsonConvert.DeserializeObject<T>(json);
    }

    public static string Serialize<T>(T value)
    {
      return JsonConvert.SerializeObject(value);
    }
  }
}
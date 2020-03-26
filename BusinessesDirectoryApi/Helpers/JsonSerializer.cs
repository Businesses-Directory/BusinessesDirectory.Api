using System;
using System.IO;
using Newtonsoft.Json;

namespace BusinessesDirectoryApi.Helpers
{
  public class JsonSerializer
  {
    public static T GetDataFromFile<T>(string jsonPath)
    {
      try
      {
        var jsonData = System.IO.File.ReadAllText(jsonPath);
        var data = JsonConvert.DeserializeObject<T>(jsonData);
        return data;
      }
      catch (ArgumentException ex)
      {
        Console.WriteLine("Json path argument is invalid, {0}", jsonPath);
        Console.WriteLine(ex.Message);
        throw;
      }
      catch (FileNotFoundException ex)
      {
        Console.WriteLine("Specified file was not found on path {0}", jsonPath);
        Console.WriteLine(ex.Message);
        throw;
      }
      catch (JsonException ex)
      {
        Console.WriteLine("Error deserializing JSON file on path {0}", jsonPath);
        Console.WriteLine(ex.Message);
        throw;
      }
      catch (Exception ex)
      {
        Console.WriteLine("GetData failed to read and/or deserialize file path {0}", jsonPath);
        Console.WriteLine(ex.Message);
        throw;
      }
    }
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

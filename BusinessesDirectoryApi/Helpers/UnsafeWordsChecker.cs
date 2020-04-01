using System.Collections.Generic;

namespace BusinessesDirectoryApi.Helpers
{
  public static class UnsafeWordsChecker
  {
    private static List<string> unsafeWords = new List<string>{
      "BICHO",
      "BICH0",
      "B1CHO",
      "B1CH0",
      "VICHO",
      "V1CHO",
      "VICH0",
      "V1CH0",
      "CHOCHO",
      "CH0CH0",
      "C#0C#0",
      "VERGA",
      "V3RGA",
      "V3RG4",
      "ORTO",
      "0RT0",
      "ORT0",
      "ORT0",
      "",
      "",
      "",
      "",
      "",
      "",
      "",
      "",
      "",
      "",
      "",
      "",
      "",
      "",
      "",
      "",
      "",
      "",
      "",
      "",
      "",
      "",
      "",
      "",
      "",
      "",
      "",
      "",
      "",
      "",
      "",
      "",
      "",
      "",
      "",
      "",
      "",
      "",
      "",
      "",
      "",
      "",
      "",
      "",
      "",
      "",
    };
    public static bool IsSafe(this string obj)
    {
      foreach(var word in unsafeWords)
      {
        if (obj.ToUpper().Contains(word))
        {
          return false;
        }
      }
      return true;
    }
  }
}

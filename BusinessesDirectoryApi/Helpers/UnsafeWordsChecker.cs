using System.Collections.Generic;

namespace BusinessesDirectoryApi.Helpers
{
  public static class UnsafeWordsChecker
  {
    private static List<string> unsafeWords = new List<string>{
      "BICHO",
      "bicho",
      "B!CHO",
      "b!cho"
    };
    public static bool IsSafe(this string obj)
    {
      foreach(var word in unsafeWords)
      {
        if (obj.Contains(word))
        {
          return false;
        }
      }
      return true;
    }
  }
}

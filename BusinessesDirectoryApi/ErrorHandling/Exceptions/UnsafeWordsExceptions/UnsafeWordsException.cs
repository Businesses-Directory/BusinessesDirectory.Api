using System;
using System.Net;
using BusinessesDirectoryApi.ErrorHandling.Models;

namespace BusinessesDirectoryApi.ErrorHandling.Exceptions.LocationExceptions
{
    public class UnsafeWordsException : CustomException
  {
    private readonly string Uri = "https://businessdirectory.com/errors/unsafe-words-exception";
    private readonly string Type = "warrning";
    public UnsafeWordsException(HttpStatusCode statusCode, string message) : base(message)
    {
      this.HelpLink = Uri;
      errorDetails.Type = Type;
      errorDetails.Title = "Unsafe Words";
      errorDetails.Detail = message;
      errorDetails.Status = (int) statusCode;
      errorDetails.Instance = $"urn:>>>url<<<:internal-server-error:{Guid.NewGuid()}";
    }
  }
}

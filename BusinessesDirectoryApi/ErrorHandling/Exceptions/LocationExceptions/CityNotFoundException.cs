using System;
using System.Net;
using BusinessesDirectoryApi.ErrorHandling.Models;

namespace BusinessesDirectoryApi.ErrorHandling.Exceptions.LocationExceptions
{
    public class CityNotFoundException : CustomException
  {
    private readonly string Uri = "https://businessdirectory.com/errors/city-not-found-exception";
    private readonly string Type = "warrning";
    public CityNotFoundException(HttpStatusCode statusCode, string message) : base(message)
    {
      this.HelpLink = Uri;
      errorDetails.Type = Type;
      errorDetails.Title = "City Not Found";
      errorDetails.Detail = message;
      errorDetails.Status = (int) statusCode;
      errorDetails.Instance = $"urn:>>>url<<<:internal-server-error:{Guid.NewGuid()}";
    }
  }
}

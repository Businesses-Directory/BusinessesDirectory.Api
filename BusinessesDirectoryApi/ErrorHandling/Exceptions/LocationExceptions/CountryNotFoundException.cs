using System;
using System.Net;
using BusinessesDirectoryApi.ErrorHandling.Models;

namespace BusinessesDirectoryApi.ErrorHandling.Exceptions.LocationExceptions
{
    public class CountryNotFoundException : CustomException
  {
    private readonly string Uri = "https://businessdirectory.com/errors/country-not-found-exception";
    private readonly string Type = "warrning";
    public CountryNotFoundException(HttpStatusCode statusCode, string message) : base(message)
    {
      this.HelpLink = Uri;
      errorDetails.Type = Type;
      errorDetails.Title = "Country Not Found";
      errorDetails.Detail = message;
      errorDetails.Status = (int) statusCode;
      errorDetails.Instance = $"urn:>>>url<<<:internal-server-error:{Guid.NewGuid()}";
    }
  }
}

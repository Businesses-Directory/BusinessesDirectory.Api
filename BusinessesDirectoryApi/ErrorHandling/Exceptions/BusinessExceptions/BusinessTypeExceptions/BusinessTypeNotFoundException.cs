using System;
using System.Net;
using BusinessesDirectoryApi.ErrorHandling.Models;

namespace BusinessesDirectoryApi.ErrorHandling.Exceptions.BusinessExceptions
{
  public class BusinessTypeNotFoundException : CustomException
  {
    private readonly string Uri = "https://businessdirectory.com/errors/business-type-not-found-exception";
    private readonly string Type = "warning";
    public BusinessTypeNotFoundException(HttpStatusCode statusCode, string message) : base(message)
    {
      this.HelpLink = Uri;
      errorDetails.Type = Type;
      errorDetails.Title = "Business Not Found";
      errorDetails.Detail = message;
      errorDetails.Status = (int) statusCode;
      errorDetails.Instance = $"urn:businessdirectory.com:business-type-not-found:{Guid.NewGuid()}";
    }
  }
}

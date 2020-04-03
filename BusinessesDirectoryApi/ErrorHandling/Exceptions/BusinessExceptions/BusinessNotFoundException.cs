using System;
using System.Net;
using BusinessesDirectoryApi.ErrorHandling.Models;

namespace BusinessesDirectoryApi.ErrorHandling.Exceptions.BusinessExceptions
{
  public class BusinessNotFoundException : CustomException
  {
    private readonly string Uri = "https://businessdirectory.com/errors/business-not-found-exception";
    private readonly string Type = "error";
    public BusinessNotFoundException(HttpStatusCode statusCode, string message) : base(message)
    {
      this.HelpLink = Uri;
      errorDetails.Type = Type;
      errorDetails.Title = "Business Not Found";
      errorDetails.Detail = message;
      errorDetails.Status = (int) statusCode;
      errorDetails.Instance = $"urn:businessdirectory.com:business-not-found:{Guid.NewGuid()}";
    }
  }
}

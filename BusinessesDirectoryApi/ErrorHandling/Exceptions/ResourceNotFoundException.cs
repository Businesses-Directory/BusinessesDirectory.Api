using System;
using System.Net;
using BusinessesDirectoryApi.ErrorHandling.Models;

namespace BusinessesDirectoryApi.ErrorHandling.Exceptions
{
  public class ResourceNotFoundException : CustomException
  {
    private readonly string Uri = "https://businessdirectory.com/errors/resource-not-found";
    private readonly string Type = "error";
    public ResourceNotFoundException(HttpStatusCode statusCode, string message) : base(message)
    {
      this.HelpLink = Uri;
      errorDetails.Type = Type;
      errorDetails.Title = "Resource Not Found";
      errorDetails.Detail = message;
      errorDetails.Status = (int) statusCode;
      errorDetails.Instance = $"urn:businessdirectory.com:resource-not-found:{Guid.NewGuid()}";
    }
  }
}

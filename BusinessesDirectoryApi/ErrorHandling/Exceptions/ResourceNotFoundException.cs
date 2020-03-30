using System;
using System.Net;
using BusinessesDirectoryApi.ErrorHandling.Models;

namespace BusinessesDirectoryApi.ErrorHandling.Exceptions
{
  public class ResourceNotFoundException : CustomException
  {
    private string URI = "https://url/errors/resource-not-found";
    public ResourceNotFoundException(HttpStatusCode statusCode, string message) : base(message)
    {
      this.HelpLink = URI;
      errorDetails.Type = URI;
      errorDetails.Title = "Resource was not found";
      errorDetails.Detail = message;
      errorDetails.Status = (int) statusCode;
      errorDetails.Instance = $"urn:>>>url<<<:resource-not-found:{Guid.NewGuid()}";
    }
  }
}

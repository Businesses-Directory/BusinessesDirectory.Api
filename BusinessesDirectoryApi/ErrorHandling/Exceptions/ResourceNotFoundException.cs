using System;
using System.Net;
using BusinessesDirectoryApi.ErrorHandling.Models;

namespace BusinessesDirectoryApi.ErrorHandling.Exceptions
{
  public class ResourceNotFoundException : CustomException
  {
    private readonly string Uri = "https://businessdirectory.com/errors/";
    private readonly string Type = "resource-not-found";
    public ResourceNotFoundException(HttpStatusCode statusCode, string message) : base(message)
    {
      this.HelpLink = String.Format("{0}{1}", Uri, Type);
      errorDetails.Type = Type;
      errorDetails.Title = "Resource was not found";
      errorDetails.Detail = message;
      errorDetails.Status = (int) statusCode;
      errorDetails.Instance = $"urn:>>>url<<<:resource-not-found:{Guid.NewGuid()}";
    }
  }
}

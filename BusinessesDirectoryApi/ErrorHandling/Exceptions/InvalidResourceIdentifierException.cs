using System;
using System.Net;
using BusinessesDirectoryApi.ErrorHandling.Models;

namespace BusinessesDirectoryApi.ErrorHandling.Exceptions
{
  public class InvalidResourceIdentifierException : CustomException
  {
    private readonly string Uri = "https://businessdirectory.com/errors/invalid-resource-identifier";
    private readonly string Type = "error";

    public InvalidResourceIdentifierException(HttpStatusCode statusCode, string message) : base(message)
    {
      this.HelpLink = Uri;
      errorDetails.Type = Type;
      errorDetails.Title = "Invalid Resource";
      errorDetails.Detail = message;
      errorDetails.Status = (int) statusCode;
      errorDetails.Instance = $"urn:businessdirectory.com:invalid-resource:{Guid.NewGuid()}";
    }
  }
}

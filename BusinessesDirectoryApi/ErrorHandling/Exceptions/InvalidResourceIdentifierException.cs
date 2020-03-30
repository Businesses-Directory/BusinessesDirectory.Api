using System;
using System.Net;
using BusinessesDirectoryApi.ErrorHandling.Models;

namespace BusinessesDirectoryApi.ErrorHandling.Exceptions
{
  public class InvalidResourceIdentifierException : CustomException
  {
    private string URI = "https://url/errors/invalid-resource-identifier";
    public InvalidResourceIdentifierException(HttpStatusCode statusCode, string message) : base(message)
    {
      this.HelpLink = URI;
      errorDetails.Type = URI;
      errorDetails.Title = "Invalid Resource";
      errorDetails.Detail = message;
      errorDetails.Status = (int) statusCode;
      errorDetails.Instance = $"urn:>>>url<<<:invalid-resource:{Guid.NewGuid()}";
    }
  }
}

using System;
using System.Net;
using BusinessesDirectoryApi.ErrorHandling.Models;

namespace BusinessesDirectoryApi.ErrorHandling.Exceptions
{
  public class InvalidOperationException : CustomException
  {
    private string URI = "https://url/errors/invalid-operation";
    public InvalidOperationException(HttpStatusCode statusCode, string message) : base(message)
    {
      this.HelpLink = URI;
      errorDetails.Type = URI;
      errorDetails.Title = "Invalid Operation";
      errorDetails.Detail = message;
      errorDetails.Status = (int) statusCode;
      errorDetails.Instance = $"urn:>>>url<<<:invalid-operation:{Guid.NewGuid()}";
    }
  }
}

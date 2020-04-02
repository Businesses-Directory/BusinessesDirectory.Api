using System;
using System.Net;
using BusinessesDirectoryApi.ErrorHandling.Models;

namespace BusinessesDirectoryApi.ErrorHandling.Exceptions
{
  public class InvalidOperationException : CustomException
  {
    private readonly string Uri = "https://businessdirectory.com/errors/invalid-operation";
    private readonly string Type = "error";
    public InvalidOperationException(HttpStatusCode statusCode, string message) : base(message)
    {
      this.HelpLink = Uri;
      errorDetails.Type = Type;
      errorDetails.Title = "Invalid Operation";
      errorDetails.Detail = message;
      errorDetails.Status = (int) statusCode;
      errorDetails.Instance = $"urn:businessdirectory.com:invalid-operation:{Guid.NewGuid()}";
    }
  }
}

using System;
using System.Net;
using BusinessesDirectoryApi.ErrorHandling.Models;

namespace BusinessesDirectoryApi.ErrorHandling.Exceptions
{
  public class InternalServerErrorException : CustomException
  {
    private string URI = "https://businessdirectory.com/errors/internal-server-error";
    private readonly string Type = "error";
    public InternalServerErrorException(HttpStatusCode statusCode, string message) : base(message)
    {
      this.HelpLink = URI;
      errorDetails.Type = URI;
      errorDetails.Title = "Internal Server Error";
      errorDetails.Detail = message;
      errorDetails.Status = (int) statusCode;
      errorDetails.Instance = $"urn:businessdirectory.com:internal-server-error:{Guid.NewGuid()}";
    }
  }
}

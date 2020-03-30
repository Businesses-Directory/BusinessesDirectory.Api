using System;
using System.Net;
using BusinessesDirectoryApi.ErrorHandling.Models;

namespace BusinessesDirectoryApi.ErrorHandling.Exceptions
{
  public class InternalServerErrorException : CustomException
  {
    private string URI = "-";
    public InternalServerErrorException(HttpStatusCode statusCode, string message) : base(message)
    {
      this.HelpLink = URI;
      errorDetails.Type = URI;
      errorDetails.Title = "Internal Server Error";
      errorDetails.Detail = message;
      errorDetails.Status = (int) statusCode;
      errorDetails.Instance = $"urn:>>>url<<<:internal-server-error:{Guid.NewGuid()}";
    }
  }
}

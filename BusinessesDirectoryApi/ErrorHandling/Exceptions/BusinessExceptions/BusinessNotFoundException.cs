using System;
using System.Net;
using BusinessesDirectoryApi.ErrorHandling.Models;

namespace BusinessesDirectoryApi.ErrorHandling.Exceptions.BusinessExceptions
{
  public class BusinessNotFoundException : CustomException
  {
    private readonly string Uri = "https://businessdirectory.com/errors/";
    private readonly string Type = "";
    public BusinessNotFoundException(HttpStatusCode statusCode, string message) : base(message)
    {
      this.HelpLink = String.Format("{0}{1}", Uri, Type);
      errorDetails.Type = Uri;
      errorDetails.Title = "Internal Server Error";
      errorDetails.Detail = message;
      errorDetails.Status = (int) statusCode;
      errorDetails.Instance = $"urn:>>>url<<<:internal-server-error:{Guid.NewGuid()}";
    }
  }
}

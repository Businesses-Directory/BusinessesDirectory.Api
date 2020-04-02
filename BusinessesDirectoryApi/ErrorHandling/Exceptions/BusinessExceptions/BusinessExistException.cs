using System;
using System.Net;
using BusinessesDirectoryApi.ErrorHandling.Models;

namespace BusinessesDirectoryApi.ErrorHandling.Exceptions.BusinessExceptions
{
  public class BusinessExistException : CustomException
  {
    private readonly string Uri = "https://businessdirectory.com/errors/business-exist";
    private readonly string Type = "warning";
    public BusinessExistException(HttpStatusCode statusCode, string message) : base(message)
    {
      this.HelpLink = Uri;
      errorDetails.Type = Type;
      errorDetails.Title = "Business Exist";
      errorDetails.Detail = message;
      errorDetails.Status = (int) statusCode;
      errorDetails.Instance = $"urn:businessdirectory.com:business-exist:{Guid.NewGuid()}";
    }
  }
}

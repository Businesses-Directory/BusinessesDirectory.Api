using System;
using System.Net;
using BusinessesDirectoryApi.ErrorHandling.Models;

namespace BusinessesDirectoryApi.ErrorHandling.Exceptions.BusinessExceptions
{
  public class BusinessHoursException : CustomException
  {
    private readonly string Uri = "https://businessdirectory.com/errors/business-hours";
    private readonly string Type = "warning";
    public BusinessHoursException(HttpStatusCode statusCode, string message) : base(message)
    {
      this.HelpLink = Uri;
      errorDetails.Type = Type;
      errorDetails.Title = "Business Hours Entry Error";
      errorDetails.Detail = message;
      errorDetails.Status = (int) statusCode;
      errorDetails.Instance = $"urn:businessdirectory.com:business-hours:{Guid.NewGuid()}";
    }
  }
}

using System;
using System.Net;
using System.Threading.Tasks;
using BusinessesDirectoryApi.ErrorHandling.Exceptions;
using BusinessesDirectoryApi.ErrorHandling.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace BusinessesDirectoryApi.ErrorHandling.CustomExceptionMiddleware
{
  public class ExceptionMiddleware
  {
    private readonly RequestDelegate _next;
    private readonly IHostingEnvironment _env;

    public ExceptionMiddleware(RequestDelegate next, IHostingEnvironment env)
    {
      this._next = next;
      this._env = env;
    }
    public async Task Invoke(HttpContext httpContext)
    {
      try
      {
        await _next(httpContext);
      }
      catch (Exception error)
      {
        await HandleException(httpContext, error);
      }
    }

    private Task HandleException(HttpContext context, Exception error)
    {
      context.Response.ContentType = "application/json";
      ErrorDetails errorDetails;
      try
      {
        errorDetails = ((CustomException)error).errorDetails;
      }
      catch (System.Exception)
      {
        var errorMessage = "Something went wrong, please try again later";
        if (_env.IsDevelopment())
          errorMessage = error.Message;
        var internalServerError = new InternalServerErrorException(HttpStatusCode.InternalServerError, errorMessage);
        errorDetails = internalServerError.errorDetails;
      }
      context.Response.StatusCode = (int)errorDetails.Status;
      return context.Response.WriteAsync(errorDetails.ToString());
    }
  }
}

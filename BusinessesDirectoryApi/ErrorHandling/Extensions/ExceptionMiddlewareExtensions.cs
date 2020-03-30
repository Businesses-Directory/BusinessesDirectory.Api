using BusinessesDirectoryApi.ErrorHandling.CustomExceptionMiddleware;
using Microsoft.AspNetCore.Builder;

namespace BusinessesDirectoryApi.ErrorHandling.Extensions
{
  public static class ExceptionMiddlewareExtensions
  {
    public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
    {
      app.UseMiddleware<ExceptionMiddleware>();
    }
  }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using BusinessesDirectoryApi.ErrorHandling.Models;
using Microsoft.AspNetCore.Mvc;

namespace BusinessesDirectoryApi.ErrorHandling.CustomExceptionMiddleware
{
  public static class ValidationErrorResult
  {
    public static BadRequestObjectResult GetValidationErrors(ActionContext context)
    {
      var modelStateEntries = context.ModelState.Where(e => e.Value.Errors.Count > 0).ToArray();
      var errors = new List<ValidationError>();

      var details = "See ValidationErrors for details";

      if (modelStateEntries.Any())
      {
        if (modelStateEntries.Length == 1 && modelStateEntries[0].Value.Errors.Count == 1 && modelStateEntries[0].Key == string.Empty)
        {
          details = modelStateEntries[0].Value.Errors[0].ErrorMessage;
        }
        else
        {
          foreach (var modelStateEntry in modelStateEntries)
          {
            foreach (var modelStateError in modelStateEntry.Value.Errors)
            {
              var error = new ValidationError
              {
                Name = modelStateEntry.Key,
                Description = modelStateError.ErrorMessage
              };

              errors.Add(error);
            }
          }
        }
      }

      var errorDetails = new ErrorDetails
      {
        Type = "",
        Status = (int)HttpStatusCode.BadRequest,
        Title = "Request Validation Error",
        Instance = $"urn:businessdirectory.com:{Guid.NewGuid()}",
        Detail = details,
        ValidationErrors = errors
      };
      return new BadRequestObjectResult(errorDetails);
    }
  }
}

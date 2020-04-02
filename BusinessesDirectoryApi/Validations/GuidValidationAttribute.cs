using System;
using System.ComponentModel.DataAnnotations;

namespace BusinessesDirectoryApi.Validations
{
  public class GuidValidationAttribute : ValidationAttribute
  {
    private const string DefaultErrorMessage = "Invalid parameter, please use a valid UUIDV4.";
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
      if (value != null)
      {
        Array values;
        if (value is Array)
        {
          values = value as Array;
        }
        else
        {
          values = new object[] { value };
        }
        foreach (var item in values)
        {
          if (!isValidGuid(item))
          {
            return new ValidationResult(ErrorMessage ?? DefaultErrorMessage);
          }
        }
      }
      return ValidationResult.Success;
    }
    private bool isValidGuid(object value)
    {
      return Guid.TryParse(value?.ToString(), out Guid validId);
    }
  }
}

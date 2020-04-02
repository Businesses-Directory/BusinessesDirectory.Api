using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace BusinessesDirectoryApi.Validations
{
  public class OperationHoursValidationAttribute : ValidationAttribute
  {
    private const string DefaultErrorMessage = "The business hours format is not valid. Please check your data entry.";
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
          if(!IsValidOperationHoursFormat(item))
          {
            return new ValidationResult(ErrorMessage ?? DefaultErrorMessage);
          }
        }
      }
      return ValidationResult.Success;
    }
    private bool IsValidOperationHoursFormat(object value)
    {
      var pattern = @"((1[0-2]|[1-9]):([0-5][0-9])([AP][M]))-((1[0-2]|[1-9]):([0-5][0-9])([AP][M]))";
      // var matches = Regex.Match(String.Format("{}", value), pattern, );
      var match = Regex.Match(String.Format("{0}", value), pattern, RegexOptions.ExplicitCapture);
      if (match.Success)
      {
        return true;
      }
      return false;
    }
  }
}

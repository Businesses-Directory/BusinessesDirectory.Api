using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace BusinessesDirectoryApi.ErrorHandling.Models
{
  public class ErrorDetails : ProblemDetails
  {
    public ICollection<ValidationError> ValidationErrors { get; set; }

    public override string ToString()
    {
      var camelCaseFormatter = new JsonSerializerSettings();
      camelCaseFormatter.ContractResolver = new CamelCasePropertyNamesContractResolver();
      return JsonConvert.SerializeObject(this, camelCaseFormatter);
    }
  }
}

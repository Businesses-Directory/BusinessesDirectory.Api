using BusinessesDirectoryApi.Validations;

namespace BusinessesDirectoryApi.Dtos.ParamsDtos
{
  public class BusinessSearchParams
  {
    public string Search { get; set; }
    [GuidValidationAttribute (ErrorMessage = "The id used as cityId is not a valid GUID/UUIDV4.")]
    public string CityId { get; set; }
  }
}
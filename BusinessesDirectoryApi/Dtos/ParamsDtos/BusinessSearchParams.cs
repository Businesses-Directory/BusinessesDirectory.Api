using BusinessesDirectoryApi.Validations;

namespace BusinessesDirectoryApi.Dtos.ParamsDtos
{
  public class BusinessSearchParams
  {
    public string Search { get; set; }
    public string City { get; set; }
    public string Type { get; set; }
  }
}

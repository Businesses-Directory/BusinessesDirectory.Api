using System.Threading.Tasks;
using System.Collections.Generic;
using BusinessesDirectoryApi.Dtos.ParamsDtos;
using BusinessesDirectoryApi.Dtos.CreateDtos.BusinessDtos;
using BusinessesDirectoryApi.Dtos.ReturnDtos.BusinessReturnDtos;

namespace BusinessesDirectoryApi.Services
{
  public interface IBusinessService
  {
    Task<BusinessDto> AddABusiness(BusinessToCreateDto businessToCreateDto);
    Task<ICollection<BusinessDto>> FindBusinesses(BusinessSearchParams businessSearchParams);
  }
}
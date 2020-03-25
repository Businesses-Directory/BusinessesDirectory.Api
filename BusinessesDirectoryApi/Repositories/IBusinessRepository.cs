using System.Threading.Tasks;
using System.Collections.Generic;
using BusinessesDirectoryApi.Dtos.ParamsDtos;
using BusinessesDirectoryApi.Models.BusinessModels;
using BusinessesDirectoryApi.Dtos.ReturnDtos.BusinessReturnDtos;

namespace BusinessesDirectoryApi.Repositories
{
  public interface IBusinessRepository
  {
    Task<BusinessDto> AddABusiness(Business businessToCreate);
    Task<ICollection<BusinessDto>> FindBusinesses(BusinessSearchParams businessSearchParams);
  }
}
using System.Threading.Tasks;
using System.Collections.Generic;
using BusinessesDirectoryApi.Dtos.ParamsDtos;
using BusinessesDirectoryApi.Models.BusinessModels;
using BusinessesDirectoryApi.Dtos.ReturnDtos.BusinessReturnDtos;
using System;

namespace BusinessesDirectoryApi.Repositories
{
  public interface IBusinessRepository
  {
    Task<BusinessDto> AddABusiness(Business businessToCreate);
    Task<ICollection<BusinessDto>> FindBusinesses(BusinessSearchParams businessSearchParams);
    Task<Business> FindBusinessById(Guid businessId);
    Task<BusinessDto> FindBusinessByPrimaryPhoneNumber(string phoneNumber);
    Task<BusinessDto> FindBusinessBySecondaryPhoneNumber(string phoneNumber);
  }
}

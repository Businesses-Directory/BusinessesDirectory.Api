using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using BusinessesDirectoryApi.Dtos.ReturnDtos.TypesReturnDtos;

namespace BusinessesDirectoryApi.Services.TypesServices
{
  public interface IBusinessTypeService
  {
    Task<ICollection<BusinessTypeDto>> FindBusinessTypes();
    Task<BusinessTypeDto> FindBusinessType(Guid id);
  }
}
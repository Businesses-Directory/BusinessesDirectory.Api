using System;
using AutoMapper;
using System.Threading.Tasks;
using System.Collections.Generic;
using BusinessesDirectoryApi.Repositories.TypesRepositories;
using BusinessesDirectoryApi.Dtos.ReturnDtos.TypesReturnDtos;

namespace BusinessesDirectoryApi.Services.TypesServices
{
  public class BusinessTypeService : IBusinessTypeService
  {
    private readonly IBusinessTypeRepository _businessTypeRepository;
    private readonly IMapper _mapper;
    public BusinessTypeService(IBusinessTypeRepository businessTypeRepository, IMapper mapper)
    {
      this._businessTypeRepository = businessTypeRepository;
      this._mapper = mapper;
    }
    public async Task<ICollection<BusinessTypeDto>> FindBusinessTypes()
    {
      var businessTypes = await _businessTypeRepository.FindBusinessTypes();
      return _mapper.Map<ICollection<BusinessTypeDto>>(businessTypes);
    }
    public async Task<BusinessTypeDto> FindBusinessType(Guid id)
    {
      var businessType = await _businessTypeRepository.FindBusinessType(id);
      if (businessType == null)
      {
        throw new Exception("The business type was not found.");
      }
      return _mapper.Map<BusinessTypeDto>(businessType);
    }
  }
}
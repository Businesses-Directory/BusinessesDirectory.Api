using AutoMapper;
using System.Threading.Tasks;
using System.Collections.Generic;
using BusinessesDirectoryApi.Repositories;
using BusinessesDirectoryApi.Dtos.ParamsDtos;
using BusinessesDirectoryApi.Models.BusinessModels;
using BusinessesDirectoryApi.Dtos.CreateDtos.BusinessDtos;
using BusinessesDirectoryApi.Dtos.ReturnDtos.BusinessReturnDtos;

namespace BusinessesDirectoryApi.Services
{
    public class BusinessService : IBusinessService
    {
      private readonly IBusinessRepository _businessRepository;
      private readonly IMapper _mapper;
      public BusinessService(IBusinessRepository businessRepository, IMapper mapper)
      {
        this._businessRepository = businessRepository;
        this._mapper = mapper;
      }
      public async Task<BusinessDto> AddABusiness(BusinessToCreateDto businessToCreateDto)
      {
        var businessToCreate = _mapper.Map<Business>(businessToCreateDto);
        return await _businessRepository.AddABusiness(businessToCreate);
      }
      public async Task<ICollection<BusinessDto>> FindBusinesses(BusinessSearchParams businessSearchParams)
      {
        var businesses = await _businessRepository.FindBusinesses(businessSearchParams);
        return businesses;
      }
    }
}
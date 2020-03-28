using System;
using AutoMapper;
using System.Threading.Tasks;
using System.Collections.Generic;
using BusinessesDirectoryApi.Repositories;
using BusinessesDirectoryApi.Dtos.ParamsDtos;
using BusinessesDirectoryApi.Models.BusinessModels;
using BusinessesDirectoryApi.Dtos.CreateDtos.BusinessDtos;
using BusinessesDirectoryApi.Repositories.TypesRepositories;
using BusinessesDirectoryApi.Dtos.ReturnDtos.BusinessReturnDtos;

namespace BusinessesDirectoryApi.Services
{
    public class BusinessService : IBusinessService
    {
      private readonly IBusinessRepository _businessRepository;
      private readonly ILocationRepository _locationRepository;
      private readonly IBusinessTypeRepository _businessTypeRepository;
      private readonly IMapper _mapper;
      public BusinessService(IBusinessRepository businessRepository, ILocationRepository locationRepository, IBusinessTypeRepository businessTypeRepository, IMapper mapper)
      {
        this._businessRepository = businessRepository;
        this._locationRepository = locationRepository;
        this._businessTypeRepository = businessTypeRepository;
        this._mapper = mapper;
      }
      public async Task<BusinessDto> AddABusiness(BusinessToCreateDto businessToCreateDto)
      {
        var city = await _locationRepository.FindCity(Guid.Parse(businessToCreateDto.CityId));
        if (city == null)
        {
            throw new Exception("City not found.");
        }
        var businessType = await _businessTypeRepository.FindBusinessType(Guid.Parse(businessToCreateDto.BusinessTypeId));
        if (businessType == null)
        {
            throw new Exception("Business type not found.");
        }
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

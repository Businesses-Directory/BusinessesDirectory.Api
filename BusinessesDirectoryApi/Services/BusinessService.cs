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
        var city = await _locationRepository.FindCityById(Guid.Parse(businessToCreateDto.CityId));
        if (city == null)
        {
          throw new Exception(String.Format("The city with Id: {0}, was not found.", businessToCreateDto.CityId));
        }
        var state = await _locationRepository.FindStateById(Guid.Parse(businessToCreateDto.StateId));
        if (state == null)
        {
          throw new Exception(String.Format("The state with Id: {0}, was not found.", businessToCreateDto.StateId));
        }
        else if (state.StateId != city.CityId)
        {
          throw new Exception(String.Format("The state with Id: {0}, does not match the state linked to the city.", state.StateId));
        }
        var country = await _locationRepository.FindCountryById(Guid.Parse(businessToCreateDto.CountryId));
        if (country == null)
        {
          throw new Exception(String.Format("The country with Id: {0}, was not found.", businessToCreateDto.CountryId));
        }
        if (country.CountryId != city.CountryId)
        {
          throw new Exception(String.Format("The country with Id: {0}, does not match the Id of the country linked to the city.",country.CountryId));
        }
        if (country.CountryId != state.CountryId)
        {
          throw new Exception(String.Format("The country with Id: {0}, does not match the Id of the country linked to the state.", country.CountryId));
        }
        var businessType = await _businessTypeRepository.FindBusinessType(Guid.Parse(businessToCreateDto.BusinessTypeId));
        if (businessType == null)
        {
          throw new Exception("Business type not found.");
        }
        // añadir la implementación del unsafe words checker
        // añadir location exception
        // depurar los types por exception
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

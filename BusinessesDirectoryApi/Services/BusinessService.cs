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
using BusinessesDirectoryApi.ErrorHandling.Exceptions.BusinessExceptions;
using BusinessesDirectoryApi.Helpers;
using BusinessesDirectoryApi.ErrorHandling.Exceptions.LocationExceptions;
using System.Net;

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
          throw new CityNotFoundException(HttpStatusCode.NotFound,String.Format("La ciudad indicada no pudo ser encontrada.", businessToCreateDto.CityId));
        }
        var state = await _locationRepository.FindStateById(Guid.Parse(businessToCreateDto.StateId));
        if (state == null)
        {
          throw new StateNotFoundException(HttpStatusCode.NotFound,String.Format("El estado no se encontró.", businessToCreateDto.StateId));
        }
        else if (state.StateId != city.StateId)
        {
          throw new LocationException(HttpStatusCode.BadRequest,String.Format("La ciudad no es parte del estado indicado.", state.StateId));
        }
        var country = await _locationRepository.FindCountryById(Guid.Parse(businessToCreateDto.CountryId));
        if (country == null)
        {
          throw new CountryNotFoundException(HttpStatusCode.NotFound,String.Format("El país no se encontró.", businessToCreateDto.CountryId));
        }
        if (country.CountryId != city.CountryId)
        {
          throw new LocationException(HttpStatusCode.BadRequest,String.Format("La ciudad no es parte del país indicado.",country.CountryId));
        }
        if (country.CountryId != state.CountryId)
        {
          throw new LocationException(HttpStatusCode.BadRequest,String.Format("El estado no es parte de ese país indicado..", country.CountryId));
        }
        if (businessToCreateDto.BusinessDaysAndHours.Monday == true && businessToCreateDto.BusinessDaysAndHours.MondayHours == null)
        {
          throw new BusinessHoursException(HttpStatusCode.BadRequest, "Si el negocio está abierto los lunes, indique las horas de servicio durante el día.");
        }
        else if (businessToCreateDto.BusinessDaysAndHours.Monday == false && businessToCreateDto.BusinessDaysAndHours.MondayHours != null)
        {
          throw new BusinessHoursException(HttpStatusCode.BadRequest, "Si escribió las horas de servicio para el lunes, indique si el negocio está abierto durante el día.");
        }
        if (businessToCreateDto.BusinessDaysAndHours.Tuesday == true && businessToCreateDto.BusinessDaysAndHours.TuesdayHours == null)
        {
          throw new BusinessHoursException(HttpStatusCode.BadRequest, "Si el negocio está abierto los martes, indique las horas de servicio durante el día.");
        }
        else if (businessToCreateDto.BusinessDaysAndHours.Tuesday == false && businessToCreateDto.BusinessDaysAndHours.TuesdayHours != null)
        {
          throw new BusinessHoursException(HttpStatusCode.BadRequest, "Si escribió las horas de servicio para el martes, indique si el negocio está abierto durante el día.");
        }
        if (businessToCreateDto.BusinessDaysAndHours.Wednesday == true && businessToCreateDto.BusinessDaysAndHours.WednesdayHours == null)
        {
          throw new BusinessHoursException(HttpStatusCode.BadRequest, "Si el negocio está abierto los miércoles, indique las horas de servicio durante el día.");
        }
        else if (businessToCreateDto.BusinessDaysAndHours.Wednesday == false && businessToCreateDto.BusinessDaysAndHours.WednesdayHours != null)
        {
          throw new BusinessHoursException(HttpStatusCode.BadRequest, "Si escribió las horas de servicio para el miércoles, indique si el negocio está abierto durante el día.");
        }
        if (businessToCreateDto.BusinessDaysAndHours.Thursday == true && businessToCreateDto.BusinessDaysAndHours.ThursdayHours == null)
        {
          throw new BusinessHoursException(HttpStatusCode.BadRequest, "Si el negocio está abierto los jueves, indique las horas de servicio durante el día.");
        }
        else if (businessToCreateDto.BusinessDaysAndHours.Thursday == false && businessToCreateDto.BusinessDaysAndHours.ThursdayHours != null)
        {
          throw new BusinessHoursException(HttpStatusCode.BadRequest, "Si escribió las horas de servicio para el jueves, indique si el negocio está abierto durante el día.");
        }
        if (businessToCreateDto.BusinessDaysAndHours.Friday == true && businessToCreateDto.BusinessDaysAndHours.FridayHours == null)
        {
          throw new BusinessHoursException(HttpStatusCode.BadRequest, "Si el negocio está abierto los viernes, indique las horas de servicio durante el día.");
        }
        else if (businessToCreateDto.BusinessDaysAndHours.Friday == false && businessToCreateDto.BusinessDaysAndHours.FridayHours != null)
        {
          throw new BusinessHoursException(HttpStatusCode.BadRequest, "Si escribió las horas de servicio para el viernes, indique si el negocio está abierto durante el día.");
        }
        if (businessToCreateDto.BusinessDaysAndHours.Saturday == true && businessToCreateDto.BusinessDaysAndHours.SaturdayHours == null)
        {
          throw new BusinessHoursException(HttpStatusCode.BadRequest, "Si el negocio está abierto los sábados, indique las horas de servicio durante el día.");
        }
        else if (businessToCreateDto.BusinessDaysAndHours.Saturday == false && businessToCreateDto.BusinessDaysAndHours.SaturdayHours != null)
        {
          throw new BusinessHoursException(HttpStatusCode.BadRequest, "Si escribió las horas de servicio para el viernes, indique si el negocio está abierto durante el día.");
        }
        if (businessToCreateDto.BusinessDaysAndHours.Sunday == true && businessToCreateDto.BusinessDaysAndHours.SundayHours == null)
        {
          throw new BusinessHoursException(HttpStatusCode.BadRequest, "Si el negocio está abierto los domingos, indique las horas de servicio durante el día.");
        }
        else if (businessToCreateDto.BusinessDaysAndHours.Sunday == false && businessToCreateDto.BusinessDaysAndHours.SundayHours != null)
        {
          throw new BusinessHoursException(HttpStatusCode.BadRequest, "Si escribió las horas de servicio para el domingo, indique si el negocio está abierto durante el día.");
        }
        var businessType = await _businessTypeRepository.FindBusinessType(Guid.Parse(businessToCreateDto.BusinessTypeId));
        if (businessType == null)
        {
          throw new BusinessTypeNotFoundException(HttpStatusCode.NotFound,"El tipo de negocio no es válido, favor de verificar las opciones disponible.");
        }
        var businessByPrimaryA = await _businessRepository.FindBusinessByPrimaryPhoneNumber(businessToCreateDto.PrimaryPhoneNumber);
        if (businessByPrimaryA != null)
        {
          throw new BusinessExistException(HttpStatusCode.BadRequest, String.Format("El negocio {0} tiene ese número telefónico, como teléfono primario.", businessByPrimaryA.BusinessName));
        }
        var businessByPrimaryB = await _businessRepository.FindBusinessBySecondaryPhoneNumber(businessToCreateDto.PrimaryPhoneNumber);
        if (businessByPrimaryB != null)
        {
          throw new BusinessExistException(HttpStatusCode.BadRequest, String.Format("El negocio {0} tiene ese número telefónico, como teléfono secundario.", businessByPrimaryB.BusinessName));
        }
        if (businessToCreateDto.SecondaryPhoneNumber != null)
        {
          var businessBySecondaryA = await _businessRepository.FindBusinessByPrimaryPhoneNumber(businessToCreateDto.SecondaryPhoneNumber);
          if (businessBySecondaryA != null)
          {
            throw new BusinessExistException(HttpStatusCode.BadRequest, String.Format("El negocio {0} tiene ese número telefónico, como teléfono primario.", businessByPrimaryB.BusinessName));
          }
          var businessBySecondaryB = await _businessRepository.FindBusinessBySecondaryPhoneNumber(businessToCreateDto.SecondaryPhoneNumber);
          if (businessBySecondaryB != null)
          {
            throw new BusinessExistException(HttpStatusCode.BadRequest, String.Format("El negocio {0} tiene ese número telefónico, como teléfono secundario.", businessByPrimaryB.BusinessName));
          }
        }
        if (UnsafeWordsChecker.IsSafe(businessToCreateDto.BusinessName))
        {
          throw new UnsafeWordsException(HttpStatusCode.BadRequest,"No se permite la entrada de palabras soeces o vocabulario inapropiado en el nombre del negocio.");
        }
        if (UnsafeWordsChecker.IsSafe(businessToCreateDto.BusinessDescription))
        {
          throw new UnsafeWordsException(HttpStatusCode.BadRequest,"No se permite la entrada de palabras soeces o vocabulario inapropiado en la descripción del negocio.");
        }
        if (UnsafeWordsChecker.IsSafe(businessToCreateDto.InFacebookAs))
        {
          throw new UnsafeWordsException(HttpStatusCode.BadRequest,"No se permite la entrada de palabras soeces o vocabulario inapropiado en la referencia de Facebook.");
        }
        if (UnsafeWordsChecker.IsSafe(businessToCreateDto.InInstagramAs))
        {
          throw new UnsafeWordsException(HttpStatusCode.BadRequest,"No se permite la entrada de palabras soeces o vocabulario inapropiado en la referencia de Instagram.");
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

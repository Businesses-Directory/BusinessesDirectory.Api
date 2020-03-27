using AutoMapper;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using BusinessesDirectoryApi.Dtos.ParamsDtos;
using BusinessesDirectoryApi.Models.ContextModel;
using BusinessesDirectoryApi.Models.BusinessModels;
using BusinessesDirectoryApi.Dtos.ReturnDtos.BusinessReturnDtos;
using System;

namespace BusinessesDirectoryApi.Repositories
{
  public class BusinessRepository : IBusinessRepository
  {
    private readonly BusinessesDirectoryContext _context;
    private readonly IMapper _mapper;
    public BusinessRepository(BusinessesDirectoryContext context, IMapper mapper)
    {
      this._context = context;
      this._mapper = mapper;
    }
    public async Task<BusinessDto> AddABusiness(Business businessToCreate)
    {
      await _context.AddAsync(businessToCreate);
      return new BusinessDto();
    }
    public async Task<ICollection<BusinessDto>> FindBusinesses(BusinessSearchParams businessSearchParams)
    {
      var businesses = _context.Business
        .Include(b => b.BusinessType)
        .Include(b => b.City)
          .ThenInclude(c => c.State)
            .ThenInclude(s => s.Country)
        .OrderBy(b => b.BusinessName)
        .AsQueryable();
      var businessesToFilter = businesses.Select(b => new BusinessDto {
        BusinessId = b.BusinessId,
        BusinessName = b.BusinessName,
        BusinessTypeName = b.BusinessType.BusinessTypeName,
        BusinessDescription = b.BusinessDescription,
        PrimaryPhoneNumber = b.PrimaryPhoneNumber,
        SecondaryPhoneNumber = b.SecondaryPhoneNumber,
        BusinessDaysAndHours = new BusinessHoursDto(b.BusinessDaysAndHours),
        CityName = b.City.CityName,
        InFacebookAs = b.InFacebookAs,
        InInstagramAs = b.InInstagramAs,
        HasDelivery = b.HasDelivery,
        HasCarryOut = b.HasCarryOut,
        HasAthMovil = b.HasAthMovil,
        InUberEats = b.InUberEats,
        InDameUnBite = b.InDameUnBite,
        InUva = b.InUva,
      });
      if (!String.IsNullOrEmpty(businessSearchParams.Search) && !String.IsNullOrWhiteSpace(businessSearchParams.Search))
      {
        businessesToFilter = businessesToFilter.Where(btf =>
          EF.Functions.Like(btf.BusinessName.ToString(), $"%{businessSearchParams.Search}%") ||
          EF.Functions.Like(btf.BusinessDescription.ToString(), $"%{businessSearchParams.Search}%") ||
          EF.Functions.Like(btf.PrimaryPhoneNumber.ToString(), $"%{businessSearchParams.Search}%") ||
          EF.Functions.Like(btf.SecondaryPhoneNumber.ToString(), $"%{businessSearchParams.Search}%")
        );
      }
      if (!String.IsNullOrEmpty(businessSearchParams.City) && !String.IsNullOrWhiteSpace(businessSearchParams.City))
      {
        businessesToFilter = businessesToFilter.Where(btf =>
          EF.Functions.Like(btf.CityName.ToString(), $"%{businessSearchParams.Search}%")
        );
      }
      if (!String.IsNullOrEmpty(businessSearchParams.City) && !String.IsNullOrWhiteSpace(businessSearchParams.City))
      {
        businessesToFilter = businessesToFilter.Where(btf =>
          EF.Functions.Like(btf.BusinessTypeName.ToString(), $"%{businessSearchParams.Search}%")
        );
      }
      var businessesToReturn = await businessesToFilter.ToListAsync();
      return _mapper.Map<ICollection<BusinessDto>>(businessesToReturn);
    }
  }
}

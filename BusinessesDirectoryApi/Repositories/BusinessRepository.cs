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
      if (!String.IsNullOrEmpty(businessSearchParams.Search) && !String.IsNullOrWhiteSpace(businessSearchParams.Search))
      {
        businesses = businesses.Where(btf =>
          EF.Functions.Like(btf.BusinessName.ToString(), $"%{businessSearchParams.Search}%") ||
          EF.Functions.Like(btf.BusinessDescription.ToString(), $"%{businessSearchParams.Search}%") ||
          EF.Functions.Like(btf.PrimaryPhoneNumber.ToString(), $"%{businessSearchParams.Search}%")
        );
      }
      if (!String.IsNullOrEmpty(businessSearchParams.City) && !String.IsNullOrWhiteSpace(businessSearchParams.City))
      {
        businesses = businesses.Where(b =>
          EF.Functions.Like(b.City.CityNormalizedName.ToString(), $"%{businessSearchParams.City}%")
        );
      }
      if (!String.IsNullOrEmpty(businessSearchParams.Type) && !String.IsNullOrWhiteSpace(businessSearchParams.Type))
      {
        businesses = businesses.Where(b =>
          EF.Functions.Like(b.BusinessType.BusinessTypeNormalizedName.ToString(), $"%{businessSearchParams.Type}%")
        );
      }
      var businessesToReturn = await businesses.ToListAsync();
      return _mapper.Map<ICollection<BusinessDto>>(businessesToReturn);
      // var businessesDto = await businesses.Select(b => new BusinessDto {
      //   BusinessId = b.BusinessId,
      //   BusinessName = b.BusinessName,
      //   BusinessType = b.BusinessType,
      //   BusinessDescription = b.BusinessDescription,
      //   PrimaryPhoneNumber = b.PrimaryPhoneNumber,
      //   SecondaryPhoneNumber = b.SecondaryPhoneNumber,
      //   BusinessDaysAndHours = new BusinessHoursDto(b.BusinessDaysAndHours),
      //   City = b.City,
      //   InFacebookAs = b.InFacebookAs,
      //   InInstagramAs = b.InInstagramAs,
      //   HasDelivery = b.HasDelivery,
      //   HasCarryOut = b.HasCarryOut,
      //   HasAthMovil = b.HasAthMovil,
      //   InUberEats = b.InUberEats,
      //   InDameUnBite = b.InDameUnBite,
      //   InUva = b.InUva,
      // }).ToListAsync();
      // return businessesDto;
      // var businessesToReturn = await businessesDto.ToListAsync();
      // return _mapper.Map<ICollection<BusinessDto>>(businessesToReturn);
    }
  }
}

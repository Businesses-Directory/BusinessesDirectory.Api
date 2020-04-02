using System;
using AutoMapper;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using BusinessesDirectoryApi.Dtos.ParamsDtos;
using BusinessesDirectoryApi.Models.ContextModel;
using BusinessesDirectoryApi.Models.BusinessModels;
using BusinessesDirectoryApi.Dtos.ReturnDtos.BusinessReturnDtos;

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
      await _context.SaveChangesAsync();
      return _mapper.Map<BusinessDto>(businessToCreate);
    }
    public async Task<ICollection<BusinessDto>> FindBusinesses(BusinessSearchParams businessSearchParams)
    {
      var businesses = _context.Business
        .Where(b => b.IsOperational == true)
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
    }
    public async Task<BusinessDto> FindBusinessByPrimaryPhoneNumber(string phoneNumber)
    {
      var business = await _context.Business.FirstOrDefaultAsync(b => b.PrimaryPhoneNumber == $"%{phoneNumber}%");
      return _mapper.Map<BusinessDto>(business);
    }
    public async Task<BusinessDto> FindBusinessBySecondaryPhoneNumber(string phoneNumber)
    {
      var business = await _context.Business.FirstOrDefaultAsync(b => b.PrimaryPhoneNumber == $"%{phoneNumber}%");
      return _mapper.Map<BusinessDto>(business);
    }
    public async Task<Business> FindBusinessById(Guid businessId)
    {
      return await _context.Business.FirstOrDefaultAsync(b => b.BusinessId == businessId);
    }
  }
}

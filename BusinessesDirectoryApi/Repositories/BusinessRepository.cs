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
      return new BusinessDto();
    }
    public async Task<ICollection<BusinessDto>> FindBusinesses(BusinessSearchParams businessSearchParams)
    {
      var businesses = _context.Business.AsQueryable();
      var businessesToreturn = await businesses.ToListAsync();
      return _mapper.Map<ICollection<BusinessDto>>(businessesToreturn);
    }
  }
}
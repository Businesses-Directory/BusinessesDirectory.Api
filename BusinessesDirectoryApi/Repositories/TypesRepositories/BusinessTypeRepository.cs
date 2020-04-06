using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessesDirectoryApi.Models.AdministrationModels;
using BusinessesDirectoryApi.Models.ContextModel;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;

namespace BusinessesDirectoryApi.Repositories.TypesRepositories
{
    public class BusinessTypeRepository : IBusinessTypeRepository
    {
        private readonly BusinessesDirectoryContext _context;
        public BusinessTypeRepository(BusinessesDirectoryContext context)
        {
            this._context = context;
        }
        public async Task<ICollection<BusinessType>> FindBusinessTypes()
        {
            return await _context.BusinessType
              .OrderBy(bt => bt.BusinessTypeNormalizedName)
              .ToListAsync();
        }
        public async Task<BusinessType> FindBusinessType(Guid id)
        {
            return await _context.BusinessType.FirstOrDefaultAsync(bt => bt.BusinessTypeId == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessesDirectoryApi.Models.AdministrationModels;

namespace BusinessesDirectoryApi.Repositories.TypesRepositories
{
  public interface IBusinessTypeRepository
  {
    Task<ICollection<BusinessType>> FindBusinessTypes();
    Task<BusinessType> FindBusinessType(Guid id);
  }
}
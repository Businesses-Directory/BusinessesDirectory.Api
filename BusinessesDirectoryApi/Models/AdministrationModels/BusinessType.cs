using System;
using System.Collections.Generic;
using BusinessesDirectoryApi.Models.BusinessModels;

namespace BusinessesDirectoryApi.Models.AdministrationModels
{
  public class BusinessType : IAuditableModel
  {
    public BusinessType()
    {
      Business = new HashSet<Business>();
    }
    public long BusinessTypeRecordId { get; set; }
    public Guid BusinessTypeId { get; set; }
    public string BusinessTypeName { get; set; }
    public string BusinessTypeNormalizedName { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? ModifiedAt { get; set; }
    // Table relationships
    public virtual ICollection<Business> Business { get; set; }
  }
}
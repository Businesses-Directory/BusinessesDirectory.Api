using System;

namespace BusinessesDirectoryApi.Models
{
  public interface IAuditableModel
  {
    DateTime CreatedAt { get; set; }
    DateTime? ModifiedAt { get; set; }
  }
}
using System;
using System.Collections.Generic;
using BusinessesDirectoryApi.Models.BusinessModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
    public string BusinessTypeDescription { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? ModifiedAt { get; set; }
    // Table relationships
    public virtual ICollection<Business> Business { get; set; }
  }
  public class BusinessTypeConfiguration : IEntityTypeConfiguration<BusinessType>
  {
    public void Configure(EntityTypeBuilder<BusinessType> entity)
    {
      entity.ToTable("BusinessType", "administration");

      entity.HasKey(e => e.BusinessTypeId)
        .HasName("BusinessTypeId_PK")
        .ForSqlServerIsClustered(false);

      entity.Property(e => e.BusinessTypeId)
        .HasDefaultValueSql("(newid())");

      entity.HasIndex(e => e.BusinessTypeRecordId)
        .HasName("BusinessRecordId_AIK")
        .IsUnique()
        .ForSqlServerIsClustered();

      entity.Property(e => e.BusinessTypeRecordId)
        .ValueGeneratedOnAdd()
        .UseSqlServerIdentityColumn()
        .Metadata.AfterSaveBehavior = PropertySaveBehavior.Ignore;

      entity.Property(e => e.BusinessTypeName)
        .IsRequired()
        .HasMaxLength(100);

      entity.Property(e => e.BusinessTypeNormalizedName)
        .IsRequired()
        .HasMaxLength(100);

      entity.Property(e => e.BusinessTypeDescription)
        .IsRequired()
        .HasMaxLength(300);
    }
  }
}
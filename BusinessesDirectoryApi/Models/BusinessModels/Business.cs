using System;
using System.Collections.Generic;
using BusinessesDirectoryApi.Helpers;
using BusinessesDirectoryApi.Models.AdministrationModels;
using BusinessesDirectoryApi.Models.LocationModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusinessesDirectoryApi.Models.BusinessModels
{
  public class Business : IAuditableModel
  {
    public long BusinessRecordId { get; set; }
    public Guid BusinessId { get; set; }
    // Business details
    public string BusinessName { get; set; }
    public Guid BusinessTypeId { get; set; }
    public string BusinessDescription { get; set; }
    public string PrimaryPhoneNumber { get; set; }
    public string SecondaryPhoneNumber { get; set; }
    public BusinessHours BusinessDaysAndHours { get; set; }
    //Business city location
    public Guid CityId { get; set; }
    public Guid StateId { get; set; }
    public Guid CountryId { get; set; }
    //Business social media names
    public string InFacebookAs { get; set; }
    public string InInstagramAs { get; set; }
    // Business Services
    public bool HasDelivery { get; set; }
    public bool HasCarryOut { get; set; }
    public bool HasAthMovil { get; set; }
    // Food services platforms found
    public bool InUberEats { get; set; }
    public bool InDameUnBite { get; set; }
    public bool InUva { get; set; }
    public bool IsOperational { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? ModifiedAt { get; set; }
    // Table Relationships
    public virtual City City { get; set; }
    public virtual BusinessType BusinessType { get; set; }
  }
  public class BusinessConfiguration : IEntityTypeConfiguration<Business>
  {
    public void Configure(EntityTypeBuilder<Business> entity)
    {
      entity.ToTable("Business", "dbo");

      entity.HasKey(e => e.BusinessId)
        .HasName("BusinessId_Primary_Key")
        .ForSqlServerIsClustered(false);

      entity.Property(e => e.BusinessId)
        .HasDefaultValueSql("(newid())");

      entity.HasIndex(e => e.BusinessRecordId)
        .HasName("BusinessRecordId_AIK")
        .IsUnique()
        .ForSqlServerIsClustered();

      entity.Property(e => e.BusinessRecordId)
        .ValueGeneratedOnAdd()
        .UseSqlServerIdentityColumn()
        .Metadata.AfterSaveBehavior = PropertySaveBehavior.Ignore;

      entity.Property(e => e.BusinessName)
        .IsRequired()
        .HasMaxLength(300);

      entity.HasIndex(e => e.BusinessTypeId)
        .HasName("BusinessTypeId_To_BusinessTable_FK");

      entity.Property(e => e.BusinessDescription)
        .IsRequired()
        .HasMaxLength(600);

      entity.Property(e => e.PrimaryPhoneNumber)
        .IsRequired()
        .HasMaxLength(20);

      entity.Property(e => e.SecondaryPhoneNumber)
        .HasMaxLength(20);

      entity.HasIndex(e => new { e.CityId, e.StateId, e.CountryId })
        .HasName("CityId_StateId_CountryId_To_BusinessTable_FK");

      entity.Property(e => e.BusinessDaysAndHours)
        .IsRequired()
        .HasConversion(
          e => JsonSerializer.Serialize(e),
          e => JsonSerializer.Parse<BusinessHours>(e)
        );

      entity.HasOne(e => e.City)
        .WithMany(c => c.Business)
        .HasForeignKey(e => new { e.CityId, e.StateId, e.CountryId })
        .OnDelete(DeleteBehavior.ClientSetNull)
        .HasConstraintName("City_To_Business_Fk");

      entity.HasOne(e => e.BusinessType)
        .WithMany(bt => bt.Business)
        .HasForeignKey(e => e.BusinessTypeId)
        .OnDelete(DeleteBehavior.ClientSetNull)
        .HasConstraintName("BusinessType_To_Business_Fk");
    }
  }
}

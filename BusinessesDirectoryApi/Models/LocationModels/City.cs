using System;
using System.Collections.Generic;
using BusinessesDirectoryApi.Models.BusinessModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusinessesDirectoryApi.Models.LocationModels
{
  public class City : IAuditableModel
  {
    public City()
    {
      Business = new HashSet<Business>();
    }
    public long CityRecordId { get; set; }
    public Guid CityId { get; set; }
    public Guid StateId { get; set; }
    public Guid CountryId { get; set; }
    public string CityName { get; set; }
    public string CityNormalizedName { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? ModifiedAt { get; set; }
    // Table Relationships
    public virtual State State { get; set; }
    public virtual ICollection<Business> Business { get; set; }
  }
  public class CityConfiguration : IEntityTypeConfiguration<City>
  {
    public void Configure(EntityTypeBuilder<City> entity)
    {
      entity.HasKey(e => new { e.CityId, e.StateId, e.CountryId })
        .HasName("CityId_StateId_CountryId_PK")
        .ForSqlServerIsClustered(false);

      entity.ToTable("City", "location");

      entity.Property(e => e.CityId)
        .HasDefaultValueSql("(newid())");

      entity.HasIndex(e => e.CityRecordId)
        .HasName("CityRecordId_AIK")
        .IsUnique()
        .ForSqlServerIsClustered();

      entity.Property(e => e.CityRecordId)
        .ValueGeneratedOnAdd()
        .UseSqlServerIdentityColumn()
        .Metadata.AfterSaveBehavior = PropertySaveBehavior.Ignore;

      entity.HasIndex(e => new { e.StateId, e.CountryId })
        .HasName("StateId_CountryId_To_CityTable_FK");

      entity.Property(e => e.CityName)
        .IsRequired()
        .HasMaxLength(100);

      entity.Property(e => e.CityNormalizedName)
        .IsRequired()
        .HasMaxLength(100);

      entity.HasOne(e => e.State)
        .WithMany(s => s.City)
        .HasForeignKey(e => new { e.StateId, e.CountryId })
        .OnDelete(DeleteBehavior.ClientSetNull)
        .HasConstraintName("State_To_City_FK");
    }
  }
}
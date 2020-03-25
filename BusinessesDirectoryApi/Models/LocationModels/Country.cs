using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusinessesDirectoryApi.Models.LocationModels
{
  // Iso values and codes documentation
  // https://en.wikipedia.org/wiki/List_of_ISO_3166_country_codes
  public class Country : IAuditableModel
  {
    public Country()
    {
      State = new HashSet<State>();
    }
    public long CountryRecordId { get; set; }
    public Guid CountryId { get; set; }
    public string CountryName { get; set; }
    public string CountryNormalizedName { get; set; }
    public string IsoTwo { get; set; }
    public string IsoThree { get; set; }
    public long IsoNumber { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? ModifiedAt { get; set; }
    // Table Relationships
    public virtual ICollection<State> State { get; set; }
  }
  public class CountryConfiguration : IEntityTypeConfiguration<Country>
  {
    public void Configure(EntityTypeBuilder<Country> entity)
    {
      entity.ToTable("Country", "location");

      entity.HasKey(e => e.CountryId)
        .HasName("CountryId_PK")
        .ForSqlServerIsClustered(false);

      entity.Property(e => e.CountryId)
        .HasDefaultValueSql("(newid())");

      entity.HasIndex(e => e.CountryRecordId)
        .HasName("CountryRecordId_AIK")
        .IsUnique()
        .ForSqlServerIsClustered();

      entity.Property(e => e.CountryRecordId)
        .ValueGeneratedOnAdd()
        .UseSqlServerIdentityColumn()
        .Metadata.AfterSaveBehavior = PropertySaveBehavior.Ignore;

      entity.Property(e => e.IsoTwo)
        .IsRequired()
        .HasMaxLength(2);

      entity.Property(e => e.IsoThree)
        .IsRequired()
        .HasMaxLength(3);

      entity.Property(e => e.IsoNumber)
        .IsRequired()
        .HasMaxLength(3);

      entity.Property(e => e.CountryName)
        .IsRequired()
        .HasMaxLength(100);

      entity.Property(e => e.CountryNormalizedName)
        .IsRequired()
        .HasMaxLength(100);
    }
  }
}
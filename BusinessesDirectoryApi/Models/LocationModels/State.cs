using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusinessesDirectoryApi.Models.LocationModels
{
  public class State : IAuditableModel
  {
    public State()
    {
      City = new HashSet<City>();
    }
    public long StateRecordId { get; set; }
    public Guid StateId { get; set; }
    public Guid CountryId { get; set; }
    public string StateName { get; set; }
    public string StateNormalizedName { get; set; }
    public string StateCode { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? ModifiedAt { get; set; }
    // Table Relationships
    public virtual Country Country { get; set; }
    public virtual ICollection<City> City { get; set; }
  }
  public class StateConfiguration : IEntityTypeConfiguration<State>
  {
    public void Configure(EntityTypeBuilder<State> entity)
    {
      entity.HasKey(e => new { e.StateId, e.CountryId })
        .HasName("StateId_CountryId_PK")
        .ForSqlServerIsClustered(false);

      entity.ToTable("State", "location");

      entity.HasIndex(e => e.StateRecordId)
        .HasName("StateRecordId_AIK")
        .IsUnique()
        .ForSqlServerIsClustered();

      entity.HasIndex(e => e.CountryId)
        .HasName("CountryId_To_StateTable_FK");

      entity.Property(e => e.StateId)
        .HasDefaultValueSql("(newid())");

      entity.Property(e => e.StateRecordId)
        .ValueGeneratedOnAdd()
        .UseSqlServerIdentityColumn()
        .Metadata.AfterSaveBehavior = PropertySaveBehavior.Ignore;

      entity.Property(e => e.StateCode)
        .IsRequired()
        .HasMaxLength(2);

      entity.Property(e => e.StateName)
        .IsRequired()
        .HasMaxLength(100);

      entity.Property(e => e.StateNormalizedName)
        .IsRequired()
        .HasMaxLength(100);

      entity.HasOne(e => e.Country)
        .WithMany(c => c.State)
        .HasForeignKey(e => e.CountryId)
        .OnDelete(DeleteBehavior.ClientSetNull)
        .HasConstraintName("Country_To_State_FK");
    }
  }
}
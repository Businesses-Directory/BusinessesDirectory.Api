using Microsoft.EntityFrameworkCore;
using BusinessesDirectoryApi.Models.BusinessModels;
using BusinessesDirectoryApi.Models.LocationModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using BusinessesDirectoryApi.Models.AdministrationModels;
using System.Threading.Tasks;
using System.Linq;
using System.Threading;
using System;

namespace BusinessesDirectoryApi.Models.ContextModel
{
  public class BusinessesDirectoryContext : IdentityDbContext
  {
    public BusinessesDirectoryContext(){}
    public BusinessesDirectoryContext(DbContextOptions<BusinessesDirectoryContext> options) : base(options) {}
    // LocationModels DbSet
    public virtual DbSet<Country> Country { get; set; }
    public virtual DbSet<State> State { get; set; }
    public virtual DbSet<City> City { get; set; }
    public virtual DbSet<Business> Business { get; set; }
    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
    {
      var AddedEntities = ChangeTracker.Entries<IAuditableModel>().Where(E => E.State == EntityState.Added).ToList();
      AddedEntities.ForEach(E =>
        {
          E.Property(x => x.CreatedAt).CurrentValue = DateTime.UtcNow;
        }
      );
      var EditedEntities = ChangeTracker.Entries<IAuditableModel>().Where(E => E.State == EntityState.Modified).ToList();
      EditedEntities.ForEach(E =>
        {
          E.Property(x => x.ModifiedAt).CurrentValue = DateTime.UtcNow;
        }
      );
      return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }
    public override int SaveChanges()
    {
      var AddedEntities = ChangeTracker.Entries<IAuditableModel>().Where(E => E.State == EntityState.Added).ToList();
      AddedEntities.ForEach(E =>
        {
          E.Property(x => x.CreatedAt).CurrentValue = DateTime.UtcNow;
        }
      );
      var EditedEntities = ChangeTracker.Entries<IAuditableModel>().Where(E => E.State == EntityState.Modified).ToList();
      EditedEntities.ForEach(E =>
        {
          E.Property(x => x.ModifiedAt).CurrentValue = DateTime.UtcNow;
        }
      );
      return base.SaveChanges();
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
      base.OnModelCreating(builder);

      builder.ApplyConfiguration(new CountryConfiguration());

      builder.ApplyConfiguration(new StateConfiguration());

      builder.ApplyConfiguration(new CityConfiguration());

      builder.ApplyConfiguration(new BusinessTypeConfiguration());

      builder.ApplyConfiguration(new BusinessConfiguration());
    }
  }



}